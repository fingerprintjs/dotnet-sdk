using System.Net;
using Fingerprint.ServerSdk.Api;
using Fingerprint.ServerSdk.Client;
using Fingerprint.ServerSdk.Extensions;
using Fingerprint.ServerSdk.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Fingerprint.ServerSdk.FunctionalTest;

public class ApiTests : IAsyncLifetime
{
    private IHost _host;
    private IFingerprintApi _api;
    private string _eventId;
    private long _start;
    private long _end;
    private string _paginationKey;

    public async Task InitializeAsync()
    {
        var eventsResponse = await _api.SearchEventsAsync(new SearchEventsRequest()
            .WithLimit(2)
            .WithStart(_start)
            .WithEnd(_end));

        Assert.True(eventsResponse.IsOk);

        var events = eventsResponse.Ok();

        Assert.NotEmpty(events.Events);

        var first = events.Events.First();
        _eventId = first.EventId;
        _paginationKey = events.PaginationKey;
        }

    public ApiTests()
    {
        _host = CreateHostBuilder().Build();
        _api = _host.Services.GetRequiredService<IFingerprintApi>();

        var now = DateTimeOffset.UtcNow;
        _end = now.ToUnixTimeMilliseconds();
        _start = now.AddDays(-89).ToUnixTimeMilliseconds();
    }

    private static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
        .ConfigureFingerprint((_, _, options) =>
        {
            var token = Environment.GetEnvironmentVariable("SECRET_API_KEY");
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("SECRET_API_KEY is missing");
            }

            var region = Environment.GetEnvironmentVariable("REGION");
            if (!string.IsNullOrWhiteSpace(region))
            {
                options.Region = Regions.Parse(region);
            }

            var bearerToken = new BearerToken(token);
            options.AddTokens(bearerToken);
        });

    [Fact]
    public async Task GetEvent_ReturnsExpectedFields()
    {
        Assert.NotNull(_eventId);

        var eventResponse = await _api.GetEventAsync(_eventId);
        Assert.True(eventResponse.IsOk);
        var model = eventResponse.Ok();

        Assert.Multiple(() =>
        {
            Assert.NotNull(model);
            Assert.IsType<BotResult>(model.Bot);
            Assert.Equal(_eventId, model.EventId);
        });
    }

    [Fact]
    public async Task GetEvent_WrongRequestId_Throws404()
    {
        var wrongRequest = await _api.GetEventAsync("1662542583652.pLBzes");
        
        Assert.Multiple(() =>
        {
            Assert.True(wrongRequest.IsNotFound);
            var notFound = wrongRequest.NotFound();
            Assert.Equal(HttpStatusCode.NotFound, wrongRequest.StatusCode);
            Assert.Equal(ErrorCode.EventNotFound, notFound.Error.Code);
        });
    }

    [Fact]
    public async Task SearchEvents_Returns()
    {
        var start = DateTime.UtcNow.Subtract(TimeSpan.FromDays(89));
        var end = DateTime.UtcNow;

        var response = await _api.SearchEventsAsync(new SearchEventsRequest()
            .WithLimit(2)
            .WithStart(new DateTimeOffset(start, TimeSpan.Zero).ToUnixTimeMilliseconds())
            .WithEnd(new DateTimeOffset(end, TimeSpan.Zero).ToUnixTimeMilliseconds()));

        Assert.True(response.IsOk);
        Assert.NotEmpty(response.Ok().Events);
    }
    
    [Fact]
    public async Task SearchEvents_DateTime_Returns()
    {
        var start = DateTime.UtcNow.Subtract(TimeSpan.FromDays(89));
        var end = DateTime.UtcNow;

        var response = await _api.SearchEventsAsync(new SearchEventsRequest()
            .WithLimit(2)
            .WithStartDateTime(start)
            .WithEndDateTime(end)
        );

        Assert.True(response.IsOk);
        Assert.NotEmpty(response.Ok().Events);
    }

    [Fact]
    public async Task SearchEvents_Pagination()
    {
        Assert.NotNull(_paginationKey);

        var response = await _api.SearchEventsAsync(new SearchEventsRequest()
            .WithLimit(2)
            .WithStart(_start)
            .WithEnd(_end)
            .WithPaginationKey(_paginationKey));
        Assert.True(response.IsOk);
        Assert.NotEmpty(response.Ok().Events);
    }

    [Fact]
    public async Task SearchEvents_ReverseWorks()
    {
        var response = await _api.SearchEventsAsync(new SearchEventsRequest()
            .WithLimit(2)
            .WithStart(_start)
            .WithEnd(_end)
            .WithReverse(true));
        Assert.True(response.IsOk);
        var eventSearch = response.Ok();
        Assert.Equal(2, eventSearch.Events.Count);

        var oldestEvent = eventSearch.Events.First();
        var newestEvent = eventSearch.Events.Last();

        Assert.True(oldestEvent.Timestamp < newestEvent.Timestamp);

        // Try to request old events to check if they still could be deserialized
        await _api.GetEventAsync(oldestEvent.EventId);
        await _api.SearchEventsAsync(new SearchEventsRequest().WithVisitorId(oldestEvent.Identification.VisitorId));
    }

    public Task DisposeAsync()
    {
        _host.Dispose();
        return Task.CompletedTask;
    }
}
using FingerprintPro.ServerSdk.Api;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;

namespace FingerprintPro.ServerSdk.FunctionalTest;

[TestFixture]
public class ApiTests
{
    private FingerprintApi _api;
    private string _requestId;
    private string _visitorId;
    private long _start;
    private long _end;
    private string _paginationKey;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var apiKey = Environment.GetEnvironmentVariable("SECRET_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Assert.Fail("SECRET_API_KEY is not set. Provide it via environment.");
        }

        var configuration = new Configuration(apiKey!);
        _api = new FingerprintApi(configuration);

        var now = DateTimeOffset.UtcNow;
        _end = now.ToUnixTimeMilliseconds();
        // Use 89 days instead of 90 to avoid flakiness from request latency pushing the start time past the 90-day limit.
        _start = now.AddDays(-89).ToUnixTimeMilliseconds();

        var events = _api.SearchEvents(2, start: _start, end: _end);
        Assert.That(events.Events, Is.Not.Null.And.Not.Empty, "No events returned by SearchEvents.");

        var first = events.Events[0].Products.Identification.Data;
        _requestId = first.RequestId;
        _visitorId = first.VisitorId;
        _paginationKey = events.PaginationKey;
    }

    [Test]
    public void GetEvent_ReturnsExpectedFields()
    {
        var events = _api.GetEvent(_requestId);

        Assert.Multiple(() =>
        {
            Assert.That(events, Is.InstanceOf<EventsGetResponse>());
            Assert.That(events.Products, Is.InstanceOf<Products>());
            Assert.That(events.Products.Botd, Is.InstanceOf<ProductBotd>());
            Assert.That(events.Products.Identification, Is.InstanceOf<ProductIdentification>());
            Assert.That(events.Products.Identification.Data.RequestId, Is.EqualTo(_requestId));
        });
    }

    [Test]
    public void GetEvent_WrongRequestId_Throws404()
    {
        Assert.That(async () => await _api.GetEventAsync("1662542583652.pLBzes"),
            Throws.TypeOf<ApiException>()
                .With.Message.Contains("request id not found")
                .And.Property(nameof(ApiException.HttpCode)).EqualTo(404)
                .And.Property(nameof(ApiException.ErrorCode)).EqualTo(ErrorCode.RequestNotFound)
                .And.Property(nameof(ApiException.ErrorContent)).InstanceOf(typeof(ErrorResponse)));
    }

    [Test]
    public void GetVisits_WithoutRequestId()
    {
        var response = _api.GetVisits(_visitorId);

        Assert.Multiple(() =>
        {
            Assert.That(response, Is.InstanceOf<VisitorsGetResponse>());
            Assert.That(response.Visits, Is.All.InstanceOf<Visit>());
            Assert.That(response.VisitorId, Is.EqualTo(_visitorId));
        });
    }

    [Test]
    public void GetVisits_WithRequestId()
    {
        var allVisits = _api.GetVisits(_visitorId);
        Assert.That(allVisits.Visits, Is.Not.Null.And.Not.Empty, "Expected at least one visit for visitor.");

        var requestId = allVisits.Visits[0].RequestId;

        var response = _api.GetVisits(_visitorId, requestId);

        Assert.Multiple(() =>
        {
            Assert.That(response, Is.InstanceOf<VisitorsGetResponse>());
            Assert.That(response.Visits, Has.Count.EqualTo(1));
            Assert.That(response.Visits[0].RequestId, Is.EqualTo(requestId));
            Assert.That(response.VisitorId, Is.EqualTo(_visitorId));
        });
    }

    [Test]
    public void SearchEvents_Returns()
    {
        // Use 89 days instead of 90 to avoid flakiness from request latency pushing the start time past the 90-day limit.
        var start = DateTime.UtcNow.Subtract(TimeSpan.FromDays(89));
        var end = DateTime.UtcNow.Add(TimeSpan.FromDays(365));

        var response = _api.SearchEvents(
            limit: 2,
            start: new DateTimeOffset(start, TimeSpan.Zero).ToUnixTimeMilliseconds(),
            end: new DateTimeOffset(end, TimeSpan.Zero).ToUnixTimeMilliseconds()
        );

        Assert.That(response.Events, Is.Not.Empty);
    }

    [Test]
    public void SearchEvents_Pagination()
    {
        if (string.IsNullOrEmpty(_paginationKey))
        {
            Assert.Inconclusive("Initial SearchEvents response did not include a pagination key.");
        }

        var response = _api.SearchEvents(2, start: _start, end: _end, paginationKey: _paginationKey);
        Assert.That(response.Events, Is.Not.Empty);
    }

    [Test]
    public void SearchEvents_ReverseWorks()
    {
        var response = _api.SearchEvents(limit: 2, start: _start, end: _end, reverse: true);
        Assert.That(response.Events, Has.Count.EqualTo(2));

        var oldestEventIdentificationData = response.Events[0].Products.Identification.Data;
        var secondOldestEventIdentificationData = response.Events[1].Products.Identification.Data;

        Assert.Multiple(() =>
        {
            Assert.That(oldestEventIdentificationData.Timestamp, Is.Not.Null);
            Assert.That(secondOldestEventIdentificationData.Timestamp, Is.Not.Null);
        });
        Assert.That(oldestEventIdentificationData.Timestamp, Is.LessThan(secondOldestEventIdentificationData.Timestamp));

        // Try to request old events to check if they still could be deserialized
        _api.GetVisits(oldestEventIdentificationData.VisitorId);
        _api.GetEvent(oldestEventIdentificationData.RequestId);
    }
}
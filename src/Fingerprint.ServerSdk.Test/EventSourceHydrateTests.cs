using System.Text.Json;
using Fingerprint.ServerSdk.Model;
using Xunit;

namespace Fingerprint.ServerSdk.Test;

public class EventSourceHydrateTests
{
    private static JsonSerializerOptions Options()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new EventHydratingJsonConverter());
        options.Converters.Add(new EventDeviceJsonConverter());
        options.Converters.Add(new EventEdgeJsonConverter());
        options.Converters.Add(new IPInfoJsonConverter());
        return options;
    }

    [Fact]
    public void DeserializeEvent_OmittedSource_HydratesToEventDevice()
    {
        const string json = "{\"event_id\":\"1708102555327.NLOjmg\",\"timestamp\":1708102555327}";

        var ev = JsonSerializer.Deserialize<Event>(json, Options());

        Assert.NotNull(ev);
        Assert.NotNull(ev!.EventDevice);
        Assert.Null(ev.EventEdge);
        Assert.Equal("1708102555327.NLOjmg", ev.EventDevice.EventId);
        Assert.Equal(EventSource.Device, ev.EventDevice.Source);
    }

    [Fact]
    public void DeserializeEvent_SourceEdge_StaysEventEdge()
    {
        const string json =
            "{\"event_id\":\"1708102555327.NLOjmg\",\"timestamp\":1708102555327,\"source\":\"edge\",\"ip_info\":{}}";

        var ev = JsonSerializer.Deserialize<Event>(json, Options());

        Assert.NotNull(ev);
        Assert.NotNull(ev!.EventEdge);
        Assert.Null(ev.EventDevice);
        Assert.Equal(EventSource.Edge, ev.EventEdge.Source);
    }

    [Fact]
    public void DeserializeEvent_EmptySource_HydratesToEventDevice()
    {
        const string json = "{\"event_id\":\"d1\",\"timestamp\":1,\"source\":\"\"}";

        var ev = JsonSerializer.Deserialize<Event>(json, Options());

        Assert.NotNull(ev!.EventDevice);
        Assert.Equal(EventSource.Device, ev.EventDevice.Source);
    }

    [Fact]
    public void DeserializeEvent_UnknownSource_Fails()
    {
        const string json = "{\"event_id\":\"d1\",\"timestamp\":1,\"source\":\"webhook\"}";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Event>(json, Options()));
    }
}

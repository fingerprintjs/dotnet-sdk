using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace Fingerprint.ServerSdk.Model;

/// <summary>
/// Wraps generated <see cref="EventJsonConverter"/> so omit/empty source
/// hydrates to device before oneOf lookup. Survives generate via generate.sh.
/// </summary>
public sealed class EventHydratingJsonConverter : JsonConverter<Event>
{
    private static readonly EventJsonConverter Inner = new();

    public override Event Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var hydrated = EventSourceHydration.HydrateMissing(doc.RootElement);
        var hydratedReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(hydrated));
        if (!hydratedReader.Read())
        {
            throw new JsonException("event JSON must be an object");
        }

        return Inner.Read(ref hydratedReader, typeToConvert, options);
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        Inner.Write(writer, value, options);
    }
}

using System.Text.Json;
using System.Text.Json.Nodes;

namespace Fingerprint.ServerSdk.Model;

/// <summary>
/// Treats a missing, null, or empty Event <c>source</c> as <c>device</c>.
/// Unknown non-empty values fail. Never rewrites <c>edge</c>.
/// </summary>
public static class EventSourceHydration
{
    public static string HydrateMissing(JsonElement root)
    {
        if (root.ValueKind != JsonValueKind.Object)
        {
            throw new JsonException("event JSON must be an object");
        }

        var node = JsonNode.Parse(root.GetRawText()) as JsonObject
            ?? throw new JsonException("event JSON must be an object");

        if (!node.TryGetPropertyValue("source", out var sourceNode)
            || sourceNode is null
            || sourceNode.GetValueKind() == JsonValueKind.Null
            || (sourceNode.GetValueKind() == JsonValueKind.String
                && string.IsNullOrEmpty(sourceNode.GetValue<string>())))
        {
            node["source"] = "device";
            return node.ToJsonString();
        }

        if (sourceNode.GetValueKind() != JsonValueKind.String)
        {
            throw new JsonException($"unknown Event source: {sourceNode}");
        }

        var value = sourceNode.GetValue<string>();
        if (value is not "device" and not "edge")
        {
            throw new JsonException($"unknown Event source: {value}");
        }

        return root.GetRawText();
    }
}

using System.Text.Json;
using Fingerprint.ServerSdk.Model;
using Xunit;

namespace Fingerprint.ServerSdk.Test;

public class EnumDeserializationTests
{
    [Fact]
    public void ProxyTypeEnumFromStringOrDefault_UnknownValue_ReturnsCatchAll()
    {
        Assert.Equal(
            ProxyDetails.ProxyTypeEnum.UnsupportedValueSdkUpgradeRequired,
            ProxyDetails.ProxyTypeEnumFromStringOrDefault("some_future_value"));
    }

    [Fact]
    public void ProxyTypeEnumFromStringOrDefault_KnownValue_ReturnsMappedMember()
    {
        Assert.Equal(
            ProxyDetails.ProxyTypeEnum.Residential,
            ProxyDetails.ProxyTypeEnumFromStringOrDefault("residential"));
    }

    [Fact]
    public void DeserializeProxyDetails_UnknownRequiredProxyType_DoesNotThrowAndMapsToCatchAll()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new ProxyDetailsJsonConverter());

        const string json = "{\"proxy_type\":\"some_future_value\",\"last_seen_at\":1708102555327}";

        var proxyDetails = JsonSerializer.Deserialize<ProxyDetails>(json, options);

        Assert.NotNull(proxyDetails);
        Assert.Equal(
            ProxyDetails.ProxyTypeEnum.UnsupportedValueSdkUpgradeRequired,
            proxyDetails!.ProxyType);
    }
    
    [Fact]
    public void StandaloneEnumValueConverter_UnknownValue_ReturnsCatchAll()
    {
        Assert.Equal(
            ProxyConfidence.UnsupportedValueSdkUpgradeRequired,
            ProxyConfidenceValueConverter.FromStringOrDefault("some_future_value"));
    }

    [Fact]
    public void DeserializeStandaloneEnum_UnknownValue_DoesNotThrowAndMapsToCatchAll()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new ProxyConfidenceJsonConverter());

        var confidence = JsonSerializer.Deserialize<ProxyConfidence>("\"some_future_value\"", options);

        Assert.Equal(ProxyConfidence.UnsupportedValueSdkUpgradeRequired, confidence);
    }

    [Fact]
    public void SerializeInnerEnumCatchAll_WritesUnknownValue()
    {
        Assert.Equal(
            "unsupported_value_sdk_upgrade_required",
            ProxyDetails.ProxyTypeEnumToJsonValue(
                ProxyDetails.ProxyTypeEnum.UnsupportedValueSdkUpgradeRequired));
    }

    [Fact]
    public void SerializeStandaloneEnumCatchAll_WritesUnknownValue()
    {
        Assert.Equal(
            "unsupported_value_sdk_upgrade_required",
            ProxyConfidenceValueConverter.ToJsonValue(
                ProxyConfidence.UnsupportedValueSdkUpgradeRequired));
    }

    [Fact]
    public void RoundTripCatchAll_DeserializesBackToCatchAll()
    {
        // Re-deserializing the Unknown string maps back to the catch-all member.
        Assert.Equal(
            ProxyDetails.ProxyTypeEnum.UnsupportedValueSdkUpgradeRequired,
            ProxyDetails.ProxyTypeEnumFromStringOrDefault("unsupported_value_sdk_upgrade_required"));
    }
}
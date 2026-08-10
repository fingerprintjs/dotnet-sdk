using System.Globalization;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;
using System.Net.Http;
using System.Text;
using FingerprintPro.ServerSdk.Json;

namespace FingerprintPro.ServerSdk.Api;

public class FingerprintApi : IFingerprintApi
{
    private readonly ApiClient _apiClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="FingerprintApi"/> class
    /// using Configuration object
    /// </summary>
    /// <param name="configuration">An instance of Configuration</param>
    /// <returns></returns>
    public FingerprintApi(Configuration configuration)
    {
        _apiClient = new ApiClient(configuration);
    }

    #region Utils

    private void AddQueryParam(List<KeyValuePair<string, string>> queryParams, string name, object? value)
    {
        if (value is null) return;
        switch (value)
        {
            case bool b:
                queryParams.Add(new KeyValuePair<string, string>(name, b.ToString())); // "True"/"False"
                break;
            case float f:
                queryParams.Add(new KeyValuePair<string, string>(name, f.ToString("F", CultureInfo.InvariantCulture)));
                break;
            case IFormattable formattable:
                queryParams.Add(new KeyValuePair<string, string>(name, formattable.ToString(null, CultureInfo.InvariantCulture)!));
                break;
            default:
                var str = value.ToString();
                if (!string.IsNullOrEmpty(str))
                    queryParams.Add(new KeyValuePair<string, string>(name, str));
                break;
        }
    }
    #endregion

    #region GetEvent

    public EventsGetResponse GetEvent(string requestId)
    {
        return GetEventWithHttpInfo(requestId).Data;
    }

    public ApiResponse<EventsGetResponse> GetEventWithHttpInfo(string requestId)
    {
        return GetEventAsyncWithHttpInfo(requestId).Result;
    }

    public async Task<EventsGetResponse> GetEventAsync(string requestId)
    {
        return (await GetEventAsyncWithHttpInfo(requestId)).Data;
    }

    public Task<ApiResponse<EventsGetResponse>> GetEventAsyncWithHttpInfo(string requestId)
    {
        var definition = new GetEventDefinition();

        var request = new ApiRequest
        {
            OperationDefinition = definition,
            Method = HttpMethod.Get,
            Args = new[] { requestId },
        };

        return _apiClient.DoRequest<EventsGetResponse>(request);
    }

    #endregion

    #region UpdateEvent

    public void UpdateEvent(EventsUpdateRequest body, string requestId)
    {
        UpdateEventWithHttpInfo(body, requestId);
    }

    public ApiResponse<object> UpdateEventWithHttpInfo(EventsUpdateRequest body, string requestId)
    {
        return UpdateEventAsyncWithHttpInfo(body, requestId).Result;
    }

    public async Task UpdateEventAsync(EventsUpdateRequest body, string requestId)
    {
        await UpdateEventAsyncWithHttpInfo(body, requestId);
    }

    public Task<ApiResponse<object>> UpdateEventAsyncWithHttpInfo(EventsUpdateRequest body, string requestId)
    {
        var definition = new UpdateEventDefinition();
        var request = new ApiRequest()
        {
            OperationDefinition = definition,
            Method = HttpMethod.Put,
            Args = new[] { requestId },
            Body = new StringContent(JsonUtils.Serialize(body), Encoding.UTF8, "application/json"),
        };

        return _apiClient.DoRequestEmpty(request);
    }

    #endregion

    #region GetVisits

    public async Task<VisitorsGetResponse> GetVisitsAsync(string visitorId, string? requestId = null,
        string? linkedId = null,
        int? limit = null,
        string? paginationKey = null, long? before = null)
    {
        return (await GetVisitsAsyncWithHttpInfo(visitorId, requestId, linkedId, limit, paginationKey, before)).Data;
    }

    public Task<ApiResponse<VisitorsGetResponse>> GetVisitsAsyncWithHttpInfo(string visitorId, string? requestId = null,
        string? linkedId = null, int? limit = null,
        string? paginationKey = null, long? before = null)
    {
        var queryParams = new List<KeyValuePair<string, string>>();

        AddQueryParam(queryParams, "request_id", requestId);
        AddQueryParam(queryParams, "linked_id", linkedId);
        AddQueryParam(queryParams, "limit", limit);
        AddQueryParam(queryParams, "paginationKey", paginationKey);
        AddQueryParam(queryParams, "before", before);

        var definition = new GetVisitsDefinition();
        var request = new ApiRequest()
        {
            OperationDefinition = definition,
            Method = HttpMethod.Get,
            Args = new[] { visitorId },
            QueryParams = queryParams
        };

        return _apiClient.DoRequest<VisitorsGetResponse>(request);
    }

    public VisitorsGetResponse GetVisits(string visitorId, string? requestId = null, string? linkedId = null,
        int? limit = null,
        string? paginationKey = null, long? before = null)
    {
        return GetVisitsWithHttpInfo(visitorId, requestId, linkedId, limit, paginationKey, before).Data;
    }

    public ApiResponse<VisitorsGetResponse> GetVisitsWithHttpInfo(string visitorId, string? requestId = null,
        string? linkedId = null, int? limit = null,
        string? paginationKey = null, long? before = null)
    {
        return GetVisitsAsyncWithHttpInfo(visitorId, requestId, linkedId, limit, paginationKey, before).Result;
    }

    #endregion

    #region DeleteVisitorData

    public void DeleteVisitorData(string visitorId)
    {
        DeleteVisitorDataWithHttpInfo(visitorId);
    }

    public ApiResponse<object> DeleteVisitorDataWithHttpInfo(string visitorId)
    {
        return DeleteVisitorDataAsyncWithHttpInfo(visitorId).Result;
    }

    public async Task DeleteVisitorDataAsync(string visitorId)
    {
        await DeleteVisitorDataAsyncWithHttpInfo(visitorId);
    }

    public Task<ApiResponse<object>> DeleteVisitorDataAsyncWithHttpInfo(string visitorId)
    {
        var definition = new DeleteVisitorDataDefinition();

        var request = new ApiRequest
        {
            OperationDefinition = definition,
            Method = HttpMethod.Delete,
            Args = new[] { visitorId }
        };

        return _apiClient.DoRequestEmpty(request);
    }

    #endregion

    #region GetRelatedVisitors

    public RelatedVisitorsResponse GetRelatedVisitors(string visitorId)
    {
        return GetRelatedVisitorsWithHttpInfo(visitorId).Data;
    }

    public ApiResponse<RelatedVisitorsResponse> GetRelatedVisitorsWithHttpInfo(string visitorId)
    {
        return GetRelatedVisitorsAsyncWithHttpInfo(visitorId).Result;
    }

    public async Task<RelatedVisitorsResponse> GetRelatedVisitorsAsync(string visitorId)
    {
        var response = await GetRelatedVisitorsAsyncWithHttpInfo(visitorId);
        return response.Data;
    }

    public Task<ApiResponse<RelatedVisitorsResponse>> GetRelatedVisitorsAsyncWithHttpInfo(string visitorId)
    {
        var definition = new GetRelatedVisitorsDefinition();

        var request = new ApiRequest
        {
            OperationDefinition = definition,
            Method = HttpMethod.Get,
            QueryParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("visitor_id", visitorId)
            }
        };

        return _apiClient.DoRequest<RelatedVisitorsResponse>(request);
    }

    #endregion

    #region SearchEvents

    public SearchEventsResponse SearchEvents(int? limit, string paginationKey = null!, string visitorId = null!,
        string bot = null!, string ipAddress = null!, string linkedId = null!, long? start = null!, long? end = null!,
        bool? reverse = null!, bool? suspect = null!, bool? vpn = null!, bool? virtualMachine = null!,
        bool? tampering = null!, bool? antiDetectBrowser = null!, bool? incognito = null!,
        bool? privacySettings = null!, bool? jailbroken = null!, bool? frida = null!, bool? factoryReset = null!,
        bool? clonedApp = null!, bool? emulator = null!, bool? rootApps = null!, string vpnConfidence = null!,
        float? minSuspectScore = null!, bool? ipBlocklist = null!, bool? datacenter = null!,
        bool? developerTools = null!, bool? locationSpoofing = null!, bool? mitmAttack = null!, bool? rareDevice = null!,
        string? rareDevicePercentileBucket = null!, bool? proxy = null!,
        string? sdkVersion = null!, string? sdkPlatform = null!, List<string>? environment = null!,
        string? proximityId = null!, int? proximityPrecisionRadius = null!)
    {
        return SearchEventsWithHttpInfo(limit, paginationKey, visitorId, bot, ipAddress, linkedId, start, end, reverse,
            suspect, vpn, virtualMachine, tampering, antiDetectBrowser, incognito, privacySettings, jailbroken, frida,
            factoryReset, clonedApp, emulator, rootApps, vpnConfidence, minSuspectScore, ipBlocklist, datacenter,
            developerTools, locationSpoofing, mitmAttack, rareDevice, rareDevicePercentileBucket, proxy, sdkVersion, sdkPlatform, environment, proximityId, proximityPrecisionRadius).Data;
    }

    public ApiResponse<SearchEventsResponse> SearchEventsWithHttpInfo(int? limit, string paginationKey = null!,
        string visitorId = null!, string bot = null!, string ipAddress = null!, string linkedId = null!,
        long? start = null!, long? end = null!, bool? reverse = null!, bool? suspect = null!, bool? vpn = null!,
        bool? virtualMachine = null!, bool? tampering = null!, bool? antiDetectBrowser = null!, bool? incognito = null!,
        bool? privacySettings = null!, bool? jailbroken = null!, bool? frida = null!, bool? factoryReset = null!,
        bool? clonedApp = null!, bool? emulator = null!, bool? rootApps = null!, string vpnConfidence = null!,
        float? minSuspectScore = null!, bool? ipBlocklist = null!, bool? datacenter = null!,
        bool? developerTools = null!, bool? locationSpoofing = null!, bool? mitmAttack = null!, bool? rareDevice = null!,
        string? rareDevicePercentileBucket = null!, bool? proxy = null!,
        string? sdkVersion = null!, string? sdkPlatform = null!, List<string>? environment = null!,
        string? proximityId = null!, int? proximityPrecisionRadius = null!)
    {
        return SearchEventsAsyncWithHttpInfo(limit, paginationKey, visitorId, bot, ipAddress, linkedId, start, end,
            reverse, suspect, vpn, virtualMachine, tampering, antiDetectBrowser, incognito, privacySettings, jailbroken,
            frida, factoryReset, clonedApp, emulator, rootApps, vpnConfidence, minSuspectScore, ipBlocklist, datacenter,
            developerTools, locationSpoofing, mitmAttack, rareDevice, rareDevicePercentileBucket, proxy, sdkVersion, sdkPlatform, environment,
            proximityId, proximityPrecisionRadius).Result;
    }

    public async Task<SearchEventsResponse> SearchEventsAsync(int? limit, string paginationKey = null!,
        string visitorId = null!, string bot = null!, string ipAddress = null!, string linkedId = null!,
        long? start = null!, long? end = null!, bool? reverse = null!, bool? suspect = null!, bool? vpn = null!,
        bool? virtualMachine = null!, bool? tampering = null!, bool? antiDetectBrowser = null!, bool? incognito = null!,
        bool? privacySettings = null!, bool? jailbroken = null!, bool? frida = null!, bool? factoryReset = null!,
        bool? clonedApp = null!, bool? emulator = null!, bool? rootApps = null!, string vpnConfidence = null!,
        float? minSuspectScore = null!, bool? ipBlocklist = null!, bool? datacenter = null!,
        bool? developerTools = null!, bool? locationSpoofing = null!, bool? mitmAttack = null!, bool? rareDevice = null!,
        string? rareDevicePercentileBucket = null!, bool? proxy = null!,
        string? sdkVersion = null!, string? sdkPlatform = null!, List<string>? environment = null!,
        string? proximityId = null!, int? proximityPrecisionRadius = null!)
    {
        var response = await SearchEventsAsyncWithHttpInfo(limit, paginationKey, visitorId, bot, ipAddress, linkedId,
            start, end, reverse, suspect, vpn, virtualMachine, tampering, antiDetectBrowser, incognito, privacySettings,
            jailbroken, frida, factoryReset, clonedApp, emulator, rootApps, vpnConfidence, minSuspectScore, ipBlocklist,
            datacenter, developerTools, locationSpoofing, mitmAttack, rareDevice, rareDevicePercentileBucket, proxy, sdkVersion, sdkPlatform, environment,
            proximityId, proximityPrecisionRadius);
        return response.Data;
    }

    public Task<ApiResponse<SearchEventsResponse>> SearchEventsAsyncWithHttpInfo(int? limit,
        string paginationKey = null!, string visitorId = null!, string bot = null!,
        string ipAddress = null!, string linkedId = null!, long? start = null!, long? end = null!,
        bool? reverse = null!, bool? suspect = null!,
        bool? vpn = null!, bool? virtualMachine = null!, bool? tampering = null!, bool? antiDetectBrowser = null!,
        bool? incognito = null!,
        bool? privacySettings = null!, bool? jailbroken = null!, bool? frida = null!, bool? factoryReset = null!,
        bool? clonedApp = null!,
        bool? emulator = null!, bool? rootApps = null!, string vpnConfidence = null!, float? minSuspectScore = null!,
        bool? ipBlocklist = null!, bool? datacenter = null!, bool? developerTools = null!,
        bool? locationSpoofing = null!, bool? mitmAttack = null!, bool? rareDevice = null!,
        string? rareDevicePercentileBucket = null!, bool? proxy = null!, string? sdkVersion = null!,
        string? sdkPlatform = null!, List<string>? environment = null!,
        string? proximityId = null!, int? proximityPrecisionRadius = null!)
    {
        var definition = new SearchEventsDefinition();

        var queryParams = new List<KeyValuePair<string, string>>();

        AddQueryParam(queryParams, "limit", limit);
        AddQueryParam(queryParams, "pagination_key", paginationKey);
        AddQueryParam(queryParams, "visitor_id", visitorId);
        AddQueryParam(queryParams, "bot", bot);
        AddQueryParam(queryParams, "ip_address", ipAddress);
        AddQueryParam(queryParams, "linked_id", linkedId);
        AddQueryParam(queryParams, "start", start);
        AddQueryParam(queryParams, "end", end);
        AddQueryParam(queryParams, "reverse", reverse);
        AddQueryParam(queryParams, "suspect", suspect);
        AddQueryParam(queryParams, "vpn", vpn);
        AddQueryParam(queryParams, "virtual_machine", virtualMachine);
        AddQueryParam(queryParams, "tampering", tampering);
        AddQueryParam(queryParams, "anti_detect_browser", antiDetectBrowser);
        AddQueryParam(queryParams, "incognito", incognito);
        AddQueryParam(queryParams, "privacy_settings", privacySettings);
        AddQueryParam(queryParams, "jailbroken", jailbroken);
        AddQueryParam(queryParams, "frida", frida);
        AddQueryParam(queryParams, "factory_reset", factoryReset);
        AddQueryParam(queryParams, "cloned_app", clonedApp);
        AddQueryParam(queryParams, "emulator", emulator);
        AddQueryParam(queryParams, "root_apps", rootApps);
        AddQueryParam(queryParams, "vpn_confidence", vpnConfidence);
        AddQueryParam(queryParams, "min_suspect_score", minSuspectScore);
        AddQueryParam(queryParams, "ip_blocklist", ipBlocklist);
        AddQueryParam(queryParams, "datacenter", datacenter);
        AddQueryParam(queryParams, "developer_tools", developerTools);
        AddQueryParam(queryParams, "location_spoofing", locationSpoofing);
        AddQueryParam(queryParams, "mitm_attack", mitmAttack);
        AddQueryParam(queryParams, "rare_device", rareDevice);
        AddQueryParam(queryParams, "rare_device_percentile_bucket", rareDevicePercentileBucket);
        AddQueryParam(queryParams, "proxy", proxy);
        AddQueryParam(queryParams, "sdk_version", sdkVersion);
        AddQueryParam(queryParams, "sdk_platform", sdkPlatform);
        AddQueryParam(queryParams, "proximity_id", proximityId);
        AddQueryParam(queryParams, "proximity_precision_radius", proximityPrecisionRadius);

        if (environment != null)
        {
            foreach (var envValue in environment)
            {
                AddQueryParam(queryParams, "environment", envValue);
            }
        }

        var request = new ApiRequest
        {
            OperationDefinition = definition,
            Method = HttpMethod.Get,
            QueryParams = queryParams
        };

        return _apiClient.DoRequest<SearchEventsResponse>(request);
    }

    #endregion
}
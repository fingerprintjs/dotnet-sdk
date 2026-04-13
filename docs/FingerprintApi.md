# Fingerprint.ServerSdk.Api.FingerprintApi

All URIs are relative to *https://api.fpjs.io/v4*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteVisitorData**](FingerprintApi.md#deletevisitordata) | **DELETE** /visitors/{visitor_id} | Delete data by visitor ID |
| [**GetEvent**](FingerprintApi.md#getevent) | **GET** /events/{event_id} | Get an event by event ID |
| [**SearchEvents**](FingerprintApi.md#searchevents) | **GET** /events | Search events |
| [**UpdateEvent**](FingerprintApi.md#updateevent) | **PATCH** /events/{event_id} | Update an event |

<a id="deletevisitordata"></a>
# **DeleteVisitorData**
> void DeleteVisitorData (string visitorId)

Delete data by visitor ID

Request deleting all data associated with the specified visitor ID. This API is useful for compliance with privacy regulations.

### Which data is deleted?
- Browser (or device) properties
- Identification requests made from this browser (or device)

#### Browser (or device) properties
- Represents the data that Fingerprint collected from this specific browser (or device) and everything inferred and derived from it.
- Upon request to delete, this data is deleted asynchronously (typically within a few minutes) and it will no longer be used to identify this browser (or device) for your [Fingerprint Workspace](https://docs.fingerprint.com/docs/glossary#fingerprint-workspace).

#### Identification requests made from this browser (or device)
- Fingerprint stores the identification requests made from a browser (or device) for up to 30 (or 90) days depending on your plan. To learn more, see [Data Retention](https://docs.fingerprint.com/docs/regions#data-retention).
- Upon request to delete, the identification requests that were made by this browser
  - Within the past 10 days are deleted within 24 hrs.
  - Outside of 10 days are allowed to purge as per your data retention period.

### Corollary
After requesting to delete a visitor ID,
- If the same browser (or device) requests to identify, it will receive a different visitor ID.
- If you request [`/v4/events` API](https://docs.fingerprint.com/reference/server-api-v4-get-event) with an `event_id` that was made outside of the 10 days, you will still receive a valid response.

### Interested?
Please [contact our support team](https://fingerprint.com/support/) to enable it for you. Otherwise, you will receive a 403.


### Example
```csharp
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Fingerprint.ServerSdk.Api;
using Fingerprint.ServerSdk.Client;
using Fingerprint.ServerSdk.Extensions;
using Fingerprint.ServerSdk.Model;

namespace DeleteVisitorDataExample
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var api = host.Services.GetRequiredService<IFingerprintApi>();

        var visitorId = "visitorId_example";  // string | The [visitor ID](https://docs.fingerprint.com/reference/js-agent-v4-get-function#visitor_id) you want to delete.

        // Delete data by visitor ID
        await api.DeleteVisitorDataAsync(visitorId);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureApi((_, _, options) =>
        {
            BearerToken token = new("YOUR_API_KEY");
            options.AddTokens(token);
        });
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **visitorId** | **string** | The [visitor ID](https://docs.fingerprint.com/reference/js-agent-v4-get-function#visitor_id) you want to delete. |  |

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK. The visitor ID is scheduled for deletion. |  -  |
| **400** | Bad request. The visitor ID parameter is missing or in the wrong format. |  -  |
| **403** | Forbidden. Access to this API is denied. |  -  |
| **404** | Not found. The visitor ID cannot be found in this workspace's data. |  -  |
| **429** | Too Many Requests. The request is throttled. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getevent"></a>
# **GetEvent**
> Event GetEvent (string eventId, string rulesetId = null)

Get an event by event ID

Get a detailed analysis of an individual identification event, including Smart Signals.

Use `event_id` as the URL path parameter. This API method is scoped to a request, i.e. all returned information is by `event_id`.


### Example
```csharp
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Fingerprint.ServerSdk.Api;
using Fingerprint.ServerSdk.Client;
using Fingerprint.ServerSdk.Extensions;
using Fingerprint.ServerSdk.Model;

namespace GetEventExample
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var api = host.Services.GetRequiredService<IFingerprintApi>();

        var eventId = "eventId_example";  // string | The unique [identifier](https://docs.fingerprint.com/reference/js-agent-v4-get-function#event_id) of each identification request (`requestId` can be used in its place).
        var rulesetId = "rulesetId_example";  // string | The ID of the ruleset to evaluate against the event, producing the action to take for this event. The resulting action is returned in the `rule_action` attribute of the response.  (optional) 

        // Get an event by event ID
        IGetEventApiResponse result = await api.GetEventAsync(eventId, rulesetId);
        Debug.WriteLine(result.Ok());
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureApi((_, _, options) =>
        {
            BearerToken token = new("YOUR_API_KEY");
            options.AddTokens(token);
        });
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **eventId** | **string** | The unique [identifier](https://docs.fingerprint.com/reference/js-agent-v4-get-function#event_id) of each identification request (`requestId` can be used in its place). |  |
| **rulesetId** | **string** | The ID of the ruleset to evaluate against the event, producing the action to take for this event. The resulting action is returned in the `rule_action` attribute of the response.  | [optional]  |

### Return type

[**Event**](Event.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK. |  -  |
| **400** | Bad request. The event Id provided is not valid. |  -  |
| **403** | Forbidden. Access to this API is denied. |  -  |
| **404** | Not found. The event Id cannot be found in this workspace's data. |  -  |
| **429** | Too Many Requests. The request is throttled. |  -  |
| **500** | Workspace error. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchevents"></a>
# **SearchEvents**
> EventSearch SearchEvents (int limit = null, string paginationKey = null, string visitorId = null, string highRecallId = null, SearchEventsBot bot = null, string ipAddress = null, string asn = null, string linkedId = null, string url = null, string bundleId = null, string packageName = null, string origin = null, long start = null, long end = null, bool reverse = null, bool suspect = null, bool vpn = null, bool virtualMachine = null, bool tampering = null, bool antiDetectBrowser = null, bool incognito = null, bool privacySettings = null, bool jailbroken = null, bool frida = null, bool factoryReset = null, bool clonedApp = null, bool emulator = null, bool rootApps = null, SearchEventsVpnConfidence vpnConfidence = null, float minSuspectScore = null, bool developerTools = null, bool locationSpoofing = null, bool mitmAttack = null, bool proxy = null, string sdkVersion = null, SearchEventsSdkPlatform sdkPlatform = null, List<string> environment = null, string proximityId = null, long totalHits = null, bool torNode = null, SearchEventsIncrementalIdentificationStatus incrementalIdentificationStatus = null, bool simulator = null)

Search events

## Search

The `/v4/events` endpoint provides a convenient way to search for past events based on specific parameters. Typical use cases and queries include:

- Searching for events associated with a single `visitor_id` within a time range to get historical behavior of a visitor.
- Searching for events associated with a single `linked_id` within a time range to get all events associated with your internal account identifier.
- Excluding all bot traffic from the query (`good` and `bad` bots)

If you don't provide `start` or `end` parameters, the default search range is the **last 7 days**.

### Filtering events with the `suspect` flag

The `/v4/events` endpoint unlocks a powerful method for fraud protection analytics. The `suspect` flag is exposed in all events where it was previously set by the update API.

You can also apply the `suspect` query parameter as a filter to find all potentially fraudulent activity that you previously marked as `suspect`. This helps identify patterns of fraudulent behavior.

### Environment scoping

If you use a secret key that is scoped to an environment, you will only get events associated with the same environment. With a workspace-scoped environment, you will get events from all environments.

Smart Signals not activated for your workspace or are not included in the response.


### Example
```csharp
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Fingerprint.ServerSdk.Api;
using Fingerprint.ServerSdk.Client;
using Fingerprint.ServerSdk.Extensions;
using Fingerprint.ServerSdk.Model;

namespace SearchEventsExample
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var api = host.Services.GetRequiredService<IFingerprintApi>();

        var limit = 10;  // int | Limit the number of events returned.  (optional)  (default to 10)
        var paginationKey = "paginationKey_example";  // string | Use `pagination_key` to get the next page of results.  When more results are available (e.g., you requested up to 100 results for your query using `limit`, but there are more than 100 events total matching your request), the `pagination_key` field is added to the response. The pagination key is an arbitrary string that should not be interpreted in any way and should be passed as-is. In the following request, use that value in the `pagination_key` parameter to get the next page of results:  1. First request, returning most recent 200 events: `GET api-base-url/events?limit=100` 2. Use `response.pagination_key` to get the next page of results: `GET api-base-url/events?limit=100&pagination_key=1740815825085`  (optional) 
        var visitorId = "visitorId_example";  // string | Unique [visitor identifier](https://docs.fingerprint.com/reference/js-agent-v4-get-function#visitor_id) issued by Fingerprint Identification and all active Smart Signals.  Filter events by matching Visitor ID (`identification.visitor_id` property).  (optional) 
        var highRecallId = "highRecallId_example";  // string | The High Recall ID is a supplementary browser identifier designed for use cases that require wider coverage over precision. Compared to the standard visitor ID, the High Recall ID strives to match incoming browsers more generously (rather than precisely) with existing browsers and thus identifies fewer browsers as new. The High Recall ID is best suited for use cases that are sensitive to browsers being identified as new and where mismatched browsers are not detrimental.  Filter events by matching High Recall ID (`supplementary_id_high_recall.visitor_id` property).  (optional) 
        var bot = (SearchEventsBot) "all";  // SearchEventsBot | Filter events by the Bot Detection result, specifically:   `all` - events where any kind of bot was detected.   `good` - events where a good bot was detected.   `bad` - events where a bad bot was detected.   `none` - events where no bot was detected. > Note: When using this parameter, only events with the `bot` property set to a valid value are returned. Events without a `bot` Smart Signal result are left out of the response.  (optional) 
        var ipAddress = "ipAddress_example";  // string | Filter events by IP address or IP range (if CIDR notation is used). If CIDR notation is not used, a /32 for IPv4 or /128 for IPv6 is assumed. Examples of range based queries: 10.0.0.0/24, 192.168.0.1/32  (optional) 
        var asn = "asn_example";  // string | Filter events by the ASN associated with the event's IP address. This corresponds to the `ip_info.(v4|v6).asn` property in the response.  (optional) 
        var linkedId = "linkedId_example";  // string | Filter events by your custom identifier.  You can use [linked Ids](https://docs.fingerprint.com/reference/js-agent-v4-get-function#linkedid) to associate identification requests with your own identifier, for example, session Id, purchase Id, or transaction Id. You can then use this `linked_id` parameter to retrieve all events associated with your custom identifier.  (optional) 
        var url = "url_example";  // string | Filter events by the URL (`url` property) associated with the event.  (optional) 
        var bundleId = "bundleId_example";  // string | Filter events by the Bundle ID (iOS) associated with the event.  (optional) 
        var packageName = "packageName_example";  // string | Filter events by the Package Name (Android) associated with the event.  (optional) 
        var origin = "origin_example";  // string | Filter events by the origin field of the event. This is applicable to web events only (e.g., https://example.com)  (optional) 
        var start = 789L;  // long | Filter events with a timestamp greater than the start time, in Unix time (milliseconds).  (optional) 
        var end = 789L;  // long | Filter events with a timestamp smaller than the end time, in Unix time (milliseconds).  (optional) 
        var reverse = true;  // bool | Sort events in reverse timestamp order.  (optional) 
        var suspect = true;  // bool | Filter events previously tagged as suspicious via the [Update API](https://docs.fingerprint.com/reference/server-api-v4-update-event). > Note: When using this parameter, only events with the `suspect` property explicitly set to `true` or `false` are returned. Events with undefined `suspect` property are left out of the response.  (optional) 
        var vpn = true;  // bool | Filter events by VPN Detection result. > Note: When using this parameter, only events with the `vpn` property set to `true` or `false` are returned. Events without a `vpn` Smart Signal result are left out of the response.  (optional) 
        var virtualMachine = true;  // bool | Filter events by Virtual Machine Detection result. > Note: When using this parameter, only events with the `virtual_machine` property set to `true` or `false` are returned. Events without a `virtual_machine` Smart Signal result are left out of the response.  (optional) 
        var tampering = true;  // bool | Filter events by Browser Tampering Detection result. > Note: When using this parameter, only events with the `tampering.result` property set to `true` or `false` are returned. Events without a `tampering` Smart Signal result are left out of the response.  (optional) 
        var antiDetectBrowser = true;  // bool | Filter events by Anti-detect Browser Detection result. > Note: When using this parameter, only events with the `tampering.anti_detect_browser` property set to `true` or `false` are returned. Events without a `tampering` Smart Signal result are left out of the response.  (optional) 
        var incognito = true;  // bool | Filter events by Browser Incognito Detection result. > Note: When using this parameter, only events with the `incognito` property set to `true` or `false` are returned. Events without an `incognito` Smart Signal result are left out of the response.  (optional) 
        var privacySettings = true;  // bool | Filter events by Privacy Settings Detection result. > Note: When using this parameter, only events with the `privacy_settings` property set to `true` or `false` are returned. Events without a `privacy_settings` Smart Signal result are left out of the response.  (optional) 
        var jailbroken = true;  // bool | Filter events by Jailbroken Device Detection result. > Note: When using this parameter, only events with the `jailbroken` property set to `true` or `false` are returned. Events without a `jailbroken` Smart Signal result are left out of the response.  (optional) 
        var frida = true;  // bool | Filter events by Frida Detection result. > Note: When using this parameter, only events with the `frida` property set to `true` or `false` are returned. Events without a `frida` Smart Signal result are left out of the response.  (optional) 
        var factoryReset = true;  // bool | Filter events by Factory Reset Detection result. > Note: When using this parameter, only events with a `factory_reset` time. Events without a `factory_reset` Smart Signal result are left out of the response.  (optional) 
        var clonedApp = true;  // bool | Filter events by Cloned App Detection result. > Note: When using this parameter, only events with the `cloned_app` property set to `true` or `false` are returned. Events without a `cloned_app` Smart Signal result are left out of the response.  (optional) 
        var emulator = true;  // bool | Filter events by Android Emulator Detection result. > Note: When using this parameter, only events with the `emulator` property set to `true` or `false` are returned. Events without an `emulator` Smart Signal result are left out of the response.  (optional) 
        var rootApps = true;  // bool | Filter events by Rooted Device Detection result. > Note: When using this parameter, only events with the `root_apps` property set to `true` or `false` are returned. Events without a `root_apps` Smart Signal result are left out of the response.  (optional) 
        var vpnConfidence = (SearchEventsVpnConfidence) "high";  // SearchEventsVpnConfidence | Filter events by VPN Detection result confidence level. `high` - events with high VPN Detection confidence. `medium` - events with medium VPN Detection confidence. `low` - events with low VPN Detection confidence. > Note: When using this parameter, only events with the `vpn.confidence` property set to a valid value are returned. Events without a `vpn` Smart Signal result are left out of the response.  (optional) 
        var minSuspectScore = 3.4F;  // float | Filter events with Suspect Score result above a provided minimum threshold. > Note: When using this parameter, only events where the `suspect_score` property set to a value exceeding your threshold are returned. Events without a `suspect_score` Smart Signal result are left out of the response.  (optional) 
        var developerTools = true;  // bool | Filter events by Developer Tools detection result. > Note: When using this parameter, only events with the `developer_tools` property set to `true` or `false` are returned. Events without a `developer_tools` Smart Signal result are left out of the response.  (optional) 
        var locationSpoofing = true;  // bool | Filter events by Location Spoofing detection result. > Note: When using this parameter, only events with the `location_spoofing` property set to `true` or `false` are returned. Events without a `location_spoofing` Smart Signal result are left out of the response.  (optional) 
        var mitmAttack = true;  // bool | Filter events by MITM (Man-in-the-Middle) Attack detection result. > Note: When using this parameter, only events with the `mitm_attack` property set to `true` or `false` are returned. Events without a `mitm_attack` Smart Signal result are left out of the response.  (optional) 
        var proxy = true;  // bool | Filter events by Proxy detection result. > Note: When using this parameter, only events with the `proxy` property set to `true` or `false` are returned. Events without a `proxy` Smart Signal result are left out of the response.  (optional) 
        var sdkVersion = "sdkVersion_example";  // string | Filter events by a specific SDK version associated with the identification event (`sdk.version` property). Example: `3.11.14`  (optional) 
        var sdkPlatform = (SearchEventsSdkPlatform) "js";  // SearchEventsSdkPlatform | Filter events by the SDK Platform associated with the identification event (`sdk.platform` property) . `js` - Javascript agent (Web). `ios` - Apple iOS based devices. `android` - Android based devices.  (optional) 
        var environment = new List<string>(); // List<string> | Filter for events by providing one or more environment IDs (`environment_id` property).  ### Array syntax To provide multiple environment IDs, use the repeated keys syntax (`environment=env1&environment=env2`). Other notations like comma-separated (`environment=env1,env2`) or bracket notation (`environment[]=env1&environment[]=env2`) are not supported.  (optional) 
        var proximityId = "proximityId_example";  // string | Filter events by the most precise Proximity ID provided by default. > Note: When using this parameter, only events with the `proximity.id` property matching the provided ID are returned. Events without a `proximity` result are left out of the response.  (optional) 
        var totalHits = 789L;  // long | When set, the response will include a `total_hits` property with a count of total query matches across all pages, up to the specified limit.  (optional) 
        var torNode = true;  // bool | Filter events by Tor Node detection result. > Note: When using this parameter, only events with the `tor_node` property set to `true` or `false` are returned. Events without a `tor_node` detection result are left out of the response.  (optional) 
        var incrementalIdentificationStatus = (SearchEventsIncrementalIdentificationStatus) "partially_completed";  // SearchEventsIncrementalIdentificationStatus | Filter events by their incremental identification status (`incremental_identification_status` property). Non incremental identification events are left out of the response.  (optional) 
        var simulator = true;  // bool | Filter events by iOS Simulator Detection result.  > Note: When using this parameter, only events with the `simulator` property set to `true` or `false` are returned. Events without a `simulator` Smart Signal result are left out of the response.  (optional) 

        // Search events
        ISearchEventsApiResponse result = await api.SearchEventsAsync(limit, paginationKey, visitorId, highRecallId, bot, ipAddress, asn, linkedId, url, bundleId, packageName, origin, start, end, reverse, suspect, vpn, virtualMachine, tampering, antiDetectBrowser, incognito, privacySettings, jailbroken, frida, factoryReset, clonedApp, emulator, rootApps, vpnConfidence, minSuspectScore, developerTools, locationSpoofing, mitmAttack, proxy, sdkVersion, sdkPlatform, environment, proximityId, totalHits, torNode, incrementalIdentificationStatus, simulator);
        Debug.WriteLine(result.Ok());
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureApi((_, _, options) =>
        {
            BearerToken token = new("YOUR_API_KEY");
            options.AddTokens(token);
        });
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **limit** | **int** | Limit the number of events returned.  | [optional] [default to 10] |
| **paginationKey** | **string** | Use `pagination_key` to get the next page of results.  When more results are available (e.g., you requested up to 100 results for your query using `limit`, but there are more than 100 events total matching your request), the `pagination_key` field is added to the response. The pagination key is an arbitrary string that should not be interpreted in any way and should be passed as-is. In the following request, use that value in the `pagination_key` parameter to get the next page of results:  1. First request, returning most recent 200 events: `GET api-base-url/events?limit=100` 2. Use `response.pagination_key` to get the next page of results: `GET api-base-url/events?limit=100&pagination_key=1740815825085`  | [optional]  |
| **visitorId** | **string** | Unique [visitor identifier](https://docs.fingerprint.com/reference/js-agent-v4-get-function#visitor_id) issued by Fingerprint Identification and all active Smart Signals.  Filter events by matching Visitor ID (`identification.visitor_id` property).  | [optional]  |
| **highRecallId** | **string** | The High Recall ID is a supplementary browser identifier designed for use cases that require wider coverage over precision. Compared to the standard visitor ID, the High Recall ID strives to match incoming browsers more generously (rather than precisely) with existing browsers and thus identifies fewer browsers as new. The High Recall ID is best suited for use cases that are sensitive to browsers being identified as new and where mismatched browsers are not detrimental.  Filter events by matching High Recall ID (`supplementary_id_high_recall.visitor_id` property).  | [optional]  |
| **bot** | **SearchEventsBot** | Filter events by the Bot Detection result, specifically:   `all` - events where any kind of bot was detected.   `good` - events where a good bot was detected.   `bad` - events where a bad bot was detected.   `none` - events where no bot was detected. > Note: When using this parameter, only events with the `bot` property set to a valid value are returned. Events without a `bot` Smart Signal result are left out of the response.  | [optional]  |
| **ipAddress** | **string** | Filter events by IP address or IP range (if CIDR notation is used). If CIDR notation is not used, a /32 for IPv4 or /128 for IPv6 is assumed. Examples of range based queries: 10.0.0.0/24, 192.168.0.1/32  | [optional]  |
| **asn** | **string** | Filter events by the ASN associated with the event's IP address. This corresponds to the `ip_info.(v4|v6).asn` property in the response.  | [optional]  |
| **linkedId** | **string** | Filter events by your custom identifier.  You can use [linked Ids](https://docs.fingerprint.com/reference/js-agent-v4-get-function#linkedid) to associate identification requests with your own identifier, for example, session Id, purchase Id, or transaction Id. You can then use this `linked_id` parameter to retrieve all events associated with your custom identifier.  | [optional]  |
| **url** | **string** | Filter events by the URL (`url` property) associated with the event.  | [optional]  |
| **bundleId** | **string** | Filter events by the Bundle ID (iOS) associated with the event.  | [optional]  |
| **packageName** | **string** | Filter events by the Package Name (Android) associated with the event.  | [optional]  |
| **origin** | **string** | Filter events by the origin field of the event. This is applicable to web events only (e.g., https://example.com)  | [optional]  |
| **start** | **long** | Filter events with a timestamp greater than the start time, in Unix time (milliseconds).  | [optional]  |
| **end** | **long** | Filter events with a timestamp smaller than the end time, in Unix time (milliseconds).  | [optional]  |
| **reverse** | **bool** | Sort events in reverse timestamp order.  | [optional]  |
| **suspect** | **bool** | Filter events previously tagged as suspicious via the [Update API](https://docs.fingerprint.com/reference/server-api-v4-update-event). > Note: When using this parameter, only events with the `suspect` property explicitly set to `true` or `false` are returned. Events with undefined `suspect` property are left out of the response.  | [optional]  |
| **vpn** | **bool** | Filter events by VPN Detection result. > Note: When using this parameter, only events with the `vpn` property set to `true` or `false` are returned. Events without a `vpn` Smart Signal result are left out of the response.  | [optional]  |
| **virtualMachine** | **bool** | Filter events by Virtual Machine Detection result. > Note: When using this parameter, only events with the `virtual_machine` property set to `true` or `false` are returned. Events without a `virtual_machine` Smart Signal result are left out of the response.  | [optional]  |
| **tampering** | **bool** | Filter events by Browser Tampering Detection result. > Note: When using this parameter, only events with the `tampering.result` property set to `true` or `false` are returned. Events without a `tampering` Smart Signal result are left out of the response.  | [optional]  |
| **antiDetectBrowser** | **bool** | Filter events by Anti-detect Browser Detection result. > Note: When using this parameter, only events with the `tampering.anti_detect_browser` property set to `true` or `false` are returned. Events without a `tampering` Smart Signal result are left out of the response.  | [optional]  |
| **incognito** | **bool** | Filter events by Browser Incognito Detection result. > Note: When using this parameter, only events with the `incognito` property set to `true` or `false` are returned. Events without an `incognito` Smart Signal result are left out of the response.  | [optional]  |
| **privacySettings** | **bool** | Filter events by Privacy Settings Detection result. > Note: When using this parameter, only events with the `privacy_settings` property set to `true` or `false` are returned. Events without a `privacy_settings` Smart Signal result are left out of the response.  | [optional]  |
| **jailbroken** | **bool** | Filter events by Jailbroken Device Detection result. > Note: When using this parameter, only events with the `jailbroken` property set to `true` or `false` are returned. Events without a `jailbroken` Smart Signal result are left out of the response.  | [optional]  |
| **frida** | **bool** | Filter events by Frida Detection result. > Note: When using this parameter, only events with the `frida` property set to `true` or `false` are returned. Events without a `frida` Smart Signal result are left out of the response.  | [optional]  |
| **factoryReset** | **bool** | Filter events by Factory Reset Detection result. > Note: When using this parameter, only events with a `factory_reset` time. Events without a `factory_reset` Smart Signal result are left out of the response.  | [optional]  |
| **clonedApp** | **bool** | Filter events by Cloned App Detection result. > Note: When using this parameter, only events with the `cloned_app` property set to `true` or `false` are returned. Events without a `cloned_app` Smart Signal result are left out of the response.  | [optional]  |
| **emulator** | **bool** | Filter events by Android Emulator Detection result. > Note: When using this parameter, only events with the `emulator` property set to `true` or `false` are returned. Events without an `emulator` Smart Signal result are left out of the response.  | [optional]  |
| **rootApps** | **bool** | Filter events by Rooted Device Detection result. > Note: When using this parameter, only events with the `root_apps` property set to `true` or `false` are returned. Events without a `root_apps` Smart Signal result are left out of the response.  | [optional]  |
| **vpnConfidence** | **SearchEventsVpnConfidence** | Filter events by VPN Detection result confidence level. `high` - events with high VPN Detection confidence. `medium` - events with medium VPN Detection confidence. `low` - events with low VPN Detection confidence. > Note: When using this parameter, only events with the `vpn.confidence` property set to a valid value are returned. Events without a `vpn` Smart Signal result are left out of the response.  | [optional]  |
| **minSuspectScore** | **float** | Filter events with Suspect Score result above a provided minimum threshold. > Note: When using this parameter, only events where the `suspect_score` property set to a value exceeding your threshold are returned. Events without a `suspect_score` Smart Signal result are left out of the response.  | [optional]  |
| **developerTools** | **bool** | Filter events by Developer Tools detection result. > Note: When using this parameter, only events with the `developer_tools` property set to `true` or `false` are returned. Events without a `developer_tools` Smart Signal result are left out of the response.  | [optional]  |
| **locationSpoofing** | **bool** | Filter events by Location Spoofing detection result. > Note: When using this parameter, only events with the `location_spoofing` property set to `true` or `false` are returned. Events without a `location_spoofing` Smart Signal result are left out of the response.  | [optional]  |
| **mitmAttack** | **bool** | Filter events by MITM (Man-in-the-Middle) Attack detection result. > Note: When using this parameter, only events with the `mitm_attack` property set to `true` or `false` are returned. Events without a `mitm_attack` Smart Signal result are left out of the response.  | [optional]  |
| **proxy** | **bool** | Filter events by Proxy detection result. > Note: When using this parameter, only events with the `proxy` property set to `true` or `false` are returned. Events without a `proxy` Smart Signal result are left out of the response.  | [optional]  |
| **sdkVersion** | **string** | Filter events by a specific SDK version associated with the identification event (`sdk.version` property). Example: `3.11.14`  | [optional]  |
| **sdkPlatform** | **SearchEventsSdkPlatform** | Filter events by the SDK Platform associated with the identification event (`sdk.platform` property) . `js` - Javascript agent (Web). `ios` - Apple iOS based devices. `android` - Android based devices.  | [optional]  |
| **environment** | [**List&lt;string&gt;**](string.md) | Filter for events by providing one or more environment IDs (`environment_id` property).  ### Array syntax To provide multiple environment IDs, use the repeated keys syntax (`environment=env1&environment=env2`). Other notations like comma-separated (`environment=env1,env2`) or bracket notation (`environment[]=env1&environment[]=env2`) are not supported.  | [optional]  |
| **proximityId** | **string** | Filter events by the most precise Proximity ID provided by default. > Note: When using this parameter, only events with the `proximity.id` property matching the provided ID are returned. Events without a `proximity` result are left out of the response.  | [optional]  |
| **totalHits** | **long** | When set, the response will include a `total_hits` property with a count of total query matches across all pages, up to the specified limit.  | [optional]  |
| **torNode** | **bool** | Filter events by Tor Node detection result. > Note: When using this parameter, only events with the `tor_node` property set to `true` or `false` are returned. Events without a `tor_node` detection result are left out of the response.  | [optional]  |
| **incrementalIdentificationStatus** | **SearchEventsIncrementalIdentificationStatus** | Filter events by their incremental identification status (`incremental_identification_status` property). Non incremental identification events are left out of the response.  | [optional]  |
| **simulator** | **bool** | Filter events by iOS Simulator Detection result.  > Note: When using this parameter, only events with the `simulator` property set to `true` or `false` are returned. Events without a `simulator` Smart Signal result are left out of the response.  | [optional]  |

### Return type

[**EventSearch**](EventSearch.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Events matching the filter(s). |  -  |
| **400** | Bad request. One or more supplied search parameters are invalid, or a required parameter is missing. |  -  |
| **403** | Forbidden. Access to this API is denied. |  -  |
| **500** | Workspace error. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updateevent"></a>
# **UpdateEvent**
> void UpdateEvent (string eventId, EventUpdate eventUpdate)

Update an event

Change information in existing events specified by `event_id` or *flag suspicious events*.

When an event is created, it can be assigned `linked_id` and `tags` submitted through the JS agent parameters. 
This information might not have been available on the client initially, so the Server API permits updating these attributes after the fact.

**Warning** It's not possible to update events older than one month. 

**Warning** Trying to update an event immediately after creation may temporarily result in an 
error (HTTP 409 Conflict. The event is not mutable yet.) as the event is fully propagated across our systems. In such a case, simply retry the request.


### Example
```csharp
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Fingerprint.ServerSdk.Api;
using Fingerprint.ServerSdk.Client;
using Fingerprint.ServerSdk.Extensions;
using Fingerprint.ServerSdk.Model;

namespace UpdateEventExample
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var api = host.Services.GetRequiredService<IFingerprintApi>();

        var eventId = "eventId_example";  // string | The unique event [identifier](https://docs.fingerprint.com/reference/js-agent-v4-get-function#event_id).
        var eventUpdate = new EventUpdate(); // EventUpdate | 

        // Update an event
        await api.UpdateEventAsync(eventId, eventUpdate);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureApi((_, _, options) =>
        {
            BearerToken token = new("YOUR_API_KEY");
            options.AddTokens(token);
        });
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **eventId** | **string** | The unique event [identifier](https://docs.fingerprint.com/reference/js-agent-v4-get-function#event_id). |  |
| **eventUpdate** | [**EventUpdate**](EventUpdate.md) |  |  |

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK. |  -  |
| **400** | Bad request. The request payload is not valid. |  -  |
| **403** | Forbidden. Access to this API is denied. |  -  |
| **404** | Not found. The event Id cannot be found in this workspace's data. |  -  |
| **409** | Conflict. The event is not mutable yet. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)


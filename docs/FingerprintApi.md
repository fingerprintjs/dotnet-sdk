# FingerprintPro.ServerSdk.Api.FingerprintApi

All URIs are relative to *https://api.fpjs.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteVisitorData**](FingerprintApi.md#deletevisitordata) | **DELETE** /visitors/{visitor_id} | Delete data by visitor ID
[**GetEvent**](FingerprintApi.md#getevent) | **GET** /events/{request_id} | Get event by request ID
[**GetRelatedVisitors**](FingerprintApi.md#getrelatedvisitors) | **GET** /related-visitors | Get Related Visitors
[**GetVisits**](FingerprintApi.md#getvisits) | **GET** /visitors/{visitor_id} | Get visits by visitor ID
[**SearchEvents**](FingerprintApi.md#searchevents) | **GET** /events/search | Get events via search
[**UpdateEvent**](FingerprintApi.md#updateevent) | **PUT** /events/{request_id} | Update an event with a given request ID

<a name="deletevisitordata"></a>
# **DeleteVisitorData**
> void DeleteVisitorData (string visitorId)

Delete data by visitor ID

> 🚧 Deprecation Notice
>
> This version of Server API is marked as deprecated starting on **Jan 7th 2026** and will be fully removed on **Jan 7th 2027** according to our [API Deprecation Policy](https://dev.fingerprint.com/reference/api-deprecation-policy). If you still use this version, please follow our [migration guide](https://dev.fingerprint.com/reference/migrating-from-server-api-v3-to-v4) to migrate from this deprecated version to the new one.

Request deleting all data associated with the specified visitor ID. This API is useful for compliance with privacy regulations.
### Which data is deleted?
- Browser (or device) properties
- Identification requests made from this browser (or device)

#### Browser (or device) properties
- Represents the data that Fingerprint collected from this specific browser (or device) and everything inferred and derived from it.
- Upon request to delete, this data is deleted asynchronously (typically within a few minutes) and it will no longer be used to identify this browser (or device) for your [Fingerprint Workspace](https://dev.fingerprint.com/docs/glossary#fingerprint-workspace).

#### Identification requests made from this browser (or device)
- Fingerprint stores the identification requests made from a browser (or device) for up to 30 (or 90) days depending on your plan. To learn more, see [Data Retention](https://dev.fingerprint.com/docs/regions#data-retention).
- Upon request to delete, the identification requests that were made by this browser
  - Within the past 10 days are deleted within 24 hrs.
  - Outside of 10 days are allowed to purge as per your data retention period.

### Corollary
After requesting to delete a visitor ID,
- If the same browser (or device) requests to identify, it will receive a different visitor ID.
- If you request [`/events` API](https://dev.fingerprint.com/reference/getevent) with a `request_id` that was made outside of the 10 days, you will still receive a valid response.
- If you request [`/visitors` API](https://dev.fingerprint.com/reference/getvisits) for the deleted visitor ID, the response will include identification requests that were made outside of those 10 days.

### Interested?
Please [contact our support team](https://fingerprint.com/support/) to enable it for you. Otherwise, you will receive a 403.


### Example
```csharp
using System;
using System.Diagnostics;
using FingerprintPro.ServerSdk.Api;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;

namespace Example
{
    public class DeleteVisitorDataExample
    {
        public void main()
        {
            var configuration = new Configuration("YOUR_API_KEY");
            var apiInstance = new FingerprintApi(configuration);
            var visitorId = visitorId_example;  // string | The [visitor ID](https://dev.fingerprint.com/reference/get-function#visitorid) you want to delete.

            try
            {
                // Delete data by visitor ID
                apiInstance.DeleteVisitorData(visitorId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FingerprintApi.DeleteVisitorData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **visitorId** | **string**| The [visitor ID](https://dev.fingerprint.com/reference/get-function#visitorid) you want to delete. | 

### Return type

void (empty response body)

### Authorization

[ApiKeyHeader](../README.md#ApiKeyHeader), [ApiKeyQuery](../README.md#ApiKeyQuery)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getevent"></a>
# **GetEvent**
> EventsGetResponse GetEvent (string requestId)

Get event by request ID

> 🚧 Deprecation Notice
>
> This version of Server API is marked as deprecated starting on **Jan 7th 2026** and will be fully removed on **Jan 7th 2027** according to our [API Deprecation Policy](https://dev.fingerprint.com/reference/api-deprecation-policy). If you still use this version, please follow our [migration guide](https://dev.fingerprint.com/reference/migrating-from-server-api-v3-to-v4#migrating-get-events) to migrate from this deprecated version to the new one.

Get a detailed analysis of an individual identification event, including Smart Signals. 
Please note that the response includes mobile signals (e.g. `rootApps`) even if the request originated from a non-mobile platform.
It is highly recommended that you **ignore** the mobile signals for such requests. 

Use `requestId` as the URL path parameter. This API method is scoped to a request, i.e. all returned information is by `requestId`.


### Example
```csharp
using System;
using System.Diagnostics;
using FingerprintPro.ServerSdk.Api;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;

namespace Example
{
    public class GetEventExample
    {
        public void main()
        {
            var configuration = new Configuration("YOUR_API_KEY");
            var apiInstance = new FingerprintApi(configuration);
            var requestId = requestId_example;  // string | The unique [identifier](https://dev.fingerprint.com/reference/get-function#requestid) of each identification request.

            try
            {
                // Get event by request ID
                EventsGetResponse result = apiInstance.GetEvent(requestId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FingerprintApi.GetEvent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **requestId** | **string**| The unique [identifier](https://dev.fingerprint.com/reference/get-function#requestid) of each identification request. | 

### Return type

[**EventsGetResponse**](EventsGetResponse.md)

### Authorization

[ApiKeyHeader](../README.md#ApiKeyHeader), [ApiKeyQuery](../README.md#ApiKeyQuery)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getrelatedvisitors"></a>
# **GetRelatedVisitors**
> RelatedVisitorsResponse GetRelatedVisitors (string visitorId)

Get Related Visitors

> 🚧 Deprecation Notice
>
> This version of Server API is marked as deprecated starting on **Jan 7th 2026** and will be fully removed on **Jan 7th 2027** according to our [API Deprecation Policy](https://dev.fingerprint.com/reference/api-deprecation-policy).

Related visitors API lets you link web visits and in-app browser visits that originated from the same mobile device.
It searches the past 6 months of identification events to find the visitor IDs that belong to the same mobile device as the given visitor ID.

⚠️ Please note that this API is not enabled by default and is billable separately. ⚠️

If you would like to use Related visitors API, please contact our [support team](https://fingerprint.com/support).
To learn more, see [Related visitors API reference](https://dev.fingerprint.com/reference/related-visitors-api).


### Example
```csharp
using System;
using System.Diagnostics;
using FingerprintPro.ServerSdk.Api;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;

namespace Example
{
    public class GetRelatedVisitorsExample
    {
        public void main()
        {
            var configuration = new Configuration("YOUR_API_KEY");
            var apiInstance = new FingerprintApi(configuration);
            var visitorId = visitorId_example;  // string | The [visitor ID](https://dev.fingerprint.com/reference/get-function#visitorid) for which you want to find the other visitor IDs that originated from the same mobile device.

            try
            {
                // Get Related Visitors
                RelatedVisitorsResponse result = apiInstance.GetRelatedVisitors(visitorId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FingerprintApi.GetRelatedVisitors: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **visitorId** | **string**| The [visitor ID](https://dev.fingerprint.com/reference/get-function#visitorid) for which you want to find the other visitor IDs that originated from the same mobile device. | 

### Return type

[**RelatedVisitorsResponse**](RelatedVisitorsResponse.md)

### Authorization

[ApiKeyHeader](../README.md#ApiKeyHeader), [ApiKeyQuery](../README.md#ApiKeyQuery)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getvisits"></a>
# **GetVisits**
> VisitorsGetResponse GetVisits (string visitorId, string requestId = null, string linkedId = null, int? limit = null, string paginationKey = null, long? before = null)

Get visits by visitor ID

> 🚧 Deprecation Notice
>
> This version of Server API is marked as deprecated starting on **Jan 7th 2026** and will be fully removed on **Jan 7th 2027** according to our [API Deprecation Policy](https://dev.fingerprint.com/reference/api-deprecation-policy). If you still use this version, please follow our [migration guide](https://dev.fingerprint.com/reference/migrating-from-server-api-v3-to-v4#migrating-get-visitors) to migrate from this deprecated version to the new one.

Get a history of visits (identification events) for a specific `visitorId`. Use the `visitorId` as a URL path parameter.
Only information from the _Identification_ product is returned.

#### Headers

* `Retry-After` — Present in case of `429 Too many requests`. Indicates how long you should wait before making a follow-up request. The value is non-negative decimal integer indicating the seconds to delay after the response is received.


### Example
```csharp
using System;
using System.Diagnostics;
using FingerprintPro.ServerSdk.Api;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;

namespace Example
{
    public class GetVisitsExample
    {
        public void main()
        {
            var configuration = new Configuration("YOUR_API_KEY");
            var apiInstance = new FingerprintApi(configuration);
            var visitorId = visitorId_example;  // string | Unique [visitor identifier](https://dev.fingerprint.com/reference/get-function#visitorid) issued by Fingerprint Identification and all active Smart Signals.
            var requestId = requestId_example;  // string | Filter visits by `requestId`.  Every identification request has a unique identifier associated with it called `requestId`. This identifier is returned to the client in the identification [result](https://dev.fingerprint.com/reference/get-function#requestid). When you filter visits by `requestId`, only one visit will be returned.  (optional) 
            var linkedId = linkedId_example;  // string | Filter visits by your custom identifier.  You can use [`linkedId`](https://dev.fingerprint.com/reference/get-function#linkedid) to associate identification requests with your own identifier, for example: session ID, purchase ID, or transaction ID. You can then use this `linked_id` parameter to retrieve all events associated with your custom identifier.  (optional) 
            var limit = 56;  // int? | Limit scanned results.  For performance reasons, the API first scans some number of events before filtering them. Use `limit` to specify how many events are scanned before they are filtered by `requestId` or `linkedId`. Results are always returned sorted by the timestamp (most recent first). By default, the most recent 100 visits are scanned, the maximum is 500.  (optional) 
            var paginationKey = paginationKey_example;  // string | Use `paginationKey` to get the next page of results.  When more results are available (e.g., you requested 200 results using `limit` parameter, but a total of 600 results are available), the `paginationKey` top-level attribute is added to the response. The key corresponds to the `requestId` of the last returned event. In the following request, use that value in the `paginationKey` parameter to get the next page of results:  1. First request, returning most recent 200 events: `GET api-base-url/visitors/:visitorId?limit=200` 2. Use `response.paginationKey` to get the next page of results: `GET api-base-url/visitors/:visitorId?limit=200&paginationKey=1683900801733.Ogvu1j`  Pagination happens during scanning and before filtering, so you can get less visits than the `limit` you specified with more available on the next page. When there are no more results available for scanning, the `paginationKey` attribute is not returned.  (optional) 
            var before = 789;  // long? | ⚠️ Deprecated pagination method, please use `paginationKey` instead. Timestamp (in milliseconds since epoch) used to paginate results.  (optional) 

            try
            {
                // Get visits by visitor ID
                VisitorsGetResponse result = apiInstance.GetVisits(visitorId, requestId, linkedId, limit, paginationKey, before);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FingerprintApi.GetVisits: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **visitorId** | **string**| Unique [visitor identifier](https://dev.fingerprint.com/reference/get-function#visitorid) issued by Fingerprint Identification and all active Smart Signals. | 
 **requestId** | **string**| Filter visits by `requestId`.  Every identification request has a unique identifier associated with it called `requestId`. This identifier is returned to the client in the identification [result](https://dev.fingerprint.com/reference/get-function#requestid). When you filter visits by `requestId`, only one visit will be returned.  | [optional] 
 **linkedId** | **string**| Filter visits by your custom identifier.  You can use [`linkedId`](https://dev.fingerprint.com/reference/get-function#linkedid) to associate identification requests with your own identifier, for example: session ID, purchase ID, or transaction ID. You can then use this `linked_id` parameter to retrieve all events associated with your custom identifier.  | [optional] 
 **limit** | **int?**| Limit scanned results.  For performance reasons, the API first scans some number of events before filtering them. Use `limit` to specify how many events are scanned before they are filtered by `requestId` or `linkedId`. Results are always returned sorted by the timestamp (most recent first). By default, the most recent 100 visits are scanned, the maximum is 500.  | [optional] 
 **paginationKey** | **string**| Use `paginationKey` to get the next page of results.  When more results are available (e.g., you requested 200 results using `limit` parameter, but a total of 600 results are available), the `paginationKey` top-level attribute is added to the response. The key corresponds to the `requestId` of the last returned event. In the following request, use that value in the `paginationKey` parameter to get the next page of results:  1. First request, returning most recent 200 events: `GET api-base-url/visitors/:visitorId?limit=200` 2. Use `response.paginationKey` to get the next page of results: `GET api-base-url/visitors/:visitorId?limit=200&paginationKey=1683900801733.Ogvu1j`  Pagination happens during scanning and before filtering, so you can get less visits than the `limit` you specified with more available on the next page. When there are no more results available for scanning, the `paginationKey` attribute is not returned.  | [optional] 
 **before** | **long?**| ⚠️ Deprecated pagination method, please use `paginationKey` instead. Timestamp (in milliseconds since epoch) used to paginate results.  | [optional] 

### Return type

[**VisitorsGetResponse**](VisitorsGetResponse.md)

### Authorization

[ApiKeyHeader](../README.md#ApiKeyHeader), [ApiKeyQuery](../README.md#ApiKeyQuery)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchevents"></a>
# **SearchEvents**
> SearchEventsResponse SearchEvents (int? limit, string paginationKey = null, string visitorId = null, string bot = null, string ipAddress = null, string linkedId = null, long? start = null, long? end = null, bool? reverse = null, bool? suspect = null, bool? vpn = null, bool? virtualMachine = null, bool? tampering = null, bool? antiDetectBrowser = null, bool? incognito = null, bool? privacySettings = null, bool? jailbroken = null, bool? frida = null, bool? factoryReset = null, bool? clonedApp = null, bool? emulator = null, bool? rootApps = null, string vpnConfidence = null, float? minSuspectScore = null, bool? ipBlocklist = null, bool? datacenter = null, bool? developerTools = null, bool? locationSpoofing = null, bool? mitmAttack = null, bool? rareDevice = null, string rareDevicePercentileBucket = null, bool? proxy = null, string sdkVersion = null, string sdkPlatform = null, List<string> environment = null, string proximityId = null, int? proximityPrecisionRadius = null)

Get events via search

> 🚧 Deprecation Notice
>
> This version of Server API is marked as deprecated starting on **Jan 7th 2026** and will be fully removed on **Jan 7th 2027** according to our [API Deprecation Policy](https://dev.fingerprint.com/reference/api-deprecation-policy). If you still use this version, please follow our [migration guide](https://dev.fingerprint.com/reference/migrating-from-server-api-v3-to-v4#migrating-get-eventssearch) to migrate from this deprecated version to the new one.

Search for identification events, including Smart Signals, using multiple filtering criteria. If you don't provide `start` or `end` parameters, the default search range is the last 7 days.

Please note that events include mobile signals (e.g. `rootApps`) even if the request originated from a non-mobile platform. We recommend you **ignore** mobile signals for such requests.


### Example
```csharp
using System;
using System.Diagnostics;
using FingerprintPro.ServerSdk.Api;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;

namespace Example
{
    public class SearchEventsExample
    {
        public void main()
        {
            var configuration = new Configuration("YOUR_API_KEY");
            var apiInstance = new FingerprintApi(configuration);
            var limit = 56;  // int? | Limit the number of events returned. 
            var paginationKey = paginationKey_example;  // string | Use `pagination_key` to get the next page of results.  When more results are available (e.g., you requested up to 200 results for your search using `limit`, but there are more than 200 events total matching your request), the `paginationKey` top-level attribute is added to the response. The key corresponds to the `timestamp` of the last returned event. In the following request, use that value in the `pagination_key` parameter to get the next page of results:  1. First request, returning most recent 200 events: `GET api-base-url/events/search?limit=200` 2. Use `response.paginationKey` to get the next page of results: `GET api-base-url/events/search?limit=200&pagination_key=1740815825085`  (optional) 
            var visitorId = visitorId_example;  // string | Unique [visitor identifier](https://dev.fingerprint.com/reference/get-function#visitorid) issued by Fingerprint Identification and all active Smart Signals. Filter for events matching this `visitor_id`.  (optional) 
            var bot = bot_example;  // string | Filter events by the Bot Detection result, specifically:   `all` - events where any kind of bot was detected.   `good` - events where a good bot was detected.   `bad` - events where a bad bot was detected.   `none` - events where no bot was detected. > Note: When using this parameter, only events with the `products.botd.data.bot.result` property set to a valid value are returned. Events without a `products.botd` Smart Signal result are left out of the response.  (optional) 
            var ipAddress = ipAddress_example;  // string | Filter events by IP address range. The range can be as specific as a single IP (/32 for IPv4 or /128 for IPv6) All ip_address filters must use CIDR notation, for example, 10.0.0.0/24, 192.168.0.1/32  (optional) 
            var linkedId = linkedId_example;  // string | Filter events by your custom identifier.  You can use [linked IDs](https://dev.fingerprint.com/reference/get-function#linkedid) to associate identification requests with your own identifier, for example, session ID, purchase ID, or transaction ID. You can then use this `linked_id` parameter to retrieve all events associated with your custom identifier.  (optional) 
            var start = 789;  // long? | Filter events with a timestamp greater than the start time, in Unix time (milliseconds).  (optional) 
            var end = 789;  // long? | Filter events with a timestamp smaller than the end time, in Unix time (milliseconds).  (optional) 
            var reverse = true;  // bool? | Sort events in reverse timestamp order.  (optional) 
            var suspect = true;  // bool? | Filter events previously tagged as suspicious via the [Update API](https://dev.fingerprint.com/reference/updateevent). > Note: When using this parameter, only events with the `suspect` property explicitly set to `true` or `false` are returned. Events with undefined `suspect` property are left out of the response.  (optional) 
            var vpn = true;  // bool? | Filter events by VPN Detection result. > Note: When using this parameter, only events with the `products.vpn.data.result` property set to `true` or `false` are returned. Events without a `products.vpn` Smart Signal result are left out of the response.  (optional) 
            var virtualMachine = true;  // bool? | Filter events by Virtual Machine Detection result. > Note: When using this parameter, only events with the `products.virtualMachine.data.result` property set to `true` or `false` are returned. Events without a `products.virtualMachine` Smart Signal result are left out of the response.  (optional) 
            var tampering = true;  // bool? | Filter events by Tampering Detection result. > Note: When using this parameter, only events with the `products.tampering.data.result` property set to `true` or `false` are returned. Events without a `products.tampering` Smart Signal result are left out of the response.  (optional) 
            var antiDetectBrowser = true;  // bool? | Filter events by Anti-detect Browser Detection result. > Note: When using this parameter, only events with the `products.tampering.data.antiDetectBrowser` property set to `true` or `false` are returned. Events without a `products.tampering` Smart Signal result are left out of the response.  (optional) 
            var incognito = true;  // bool? | Filter events by Browser Incognito Detection result. > Note: When using this parameter, only events with the `products.incognito.data.result` property set to `true` or `false` are returned. Events without a `products.incognito` Smart Signal result are left out of the response.  (optional) 
            var privacySettings = true;  // bool? | Filter events by Privacy Settings Detection result. > Note: When using this parameter, only events with the `products.privacySettings.data.result` property set to `true` or `false` are returned. Events without a `products.privacySettings` Smart Signal result are left out of the response.  (optional) 
            var jailbroken = true;  // bool? | Filter events by Jailbroken Device Detection result. > Note: When using this parameter, only events with the `products.jailbroken.data.result` property set to `true` or `false` are returned. Events without a `products.jailbroken` Smart Signal result are left out of the response.  (optional) 
            var frida = true;  // bool? | Filter events by Frida Detection result. > Note: When using this parameter, only events with the `products.frida.data.result` property set to `true` or `false` are returned. Events without a `products.frida` Smart Signal result are left out of the response.  (optional) 
            var factoryReset = true;  // bool? | Filter events by Factory Reset Detection result. > Note: When using this parameter, only events with the `products.factoryReset.data.result` property set to `true` or `false` are returned. Events without a `products.factoryReset` Smart Signal result are left out of the response.  (optional) 
            var clonedApp = true;  // bool? | Filter events by Cloned App Detection result. > Note: When using this parameter, only events with the `products.clonedApp.data.result` property set to `true` or `false` are returned. Events without a `products.clonedApp` Smart Signal result are left out of the response.  (optional) 
            var emulator = true;  // bool? | Filter events by Android Emulator Detection result. > Note: When using this parameter, only events with the `products.emulator.data.result` property set to `true` or `false` are returned. Events without a `products.emulator` Smart Signal result are left out of the response.  (optional) 
            var rootApps = true;  // bool? | Filter events by Rooted Device Detection result. > Note: When using this parameter, only events with the `products.rootApps.data.result` property set to `true` or `false` are returned. Events without a `products.rootApps` Smart Signal result are left out of the response.  (optional) 
            var vpnConfidence = vpnConfidence_example;  // string | Filter events by VPN Detection result confidence level. `high` - events with high VPN Detection confidence. `medium` - events with medium VPN Detection confidence. `low` - events with low VPN Detection confidence. > Note: When using this parameter, only events with the `products.vpn.data.confidence` property set to a valid value are returned. Events without a `products.vpn` Smart Signal result are left out of the response.  (optional) 
            var minSuspectScore = 3.4;  // float? | Filter events with Suspect Score result above a provided minimum threshold. > Note: When using this parameter, only events where the `products.suspectScore.data.result` property set to a value exceeding your threshold are returned. Events without a `products.suspectScore` Smart Signal result are left out of the response.  (optional) 
            var ipBlocklist = true;  // bool? | Filter events by IP Blocklist Detection result. > Note: When using this parameter, only events with the `products.ipBlocklist.data.result` property set to `true` or `false` are returned. Events without a `products.ipBlocklist` Smart Signal result are left out of the response.  (optional) 
            var datacenter = true;  // bool? | Filter events by Datacenter Detection result. > Note: When using this parameter, only events with the `products.ipInfo.data.v4.datacenter.result` or `products.ipInfo.data.v6.datacenter.result` property set to `true` or `false` are returned. Events without a `products.ipInfo` Smart Signal result are left out of the response.  (optional) 
            var developerTools = true;  // bool? | Filter events by Developer Tools detection result. > Note: When using this parameter, only events with the `products.developerTools.data.result` property set to `true` or `false` are returned. Events without a `products.developerTools` Smart Signal result are left out of the response.  (optional) 
            var locationSpoofing = true;  // bool? | Filter events by Location Spoofing detection result. > Note: When using this parameter, only events with the `products.locationSpoofing.data.result` property set to `true` or `false` are returned. Events without a `products.locationSpoofing` Smart Signal result are left out of the response.  (optional) 
            var mitmAttack = true;  // bool? | Filter events by MITM (Man-in-the-Middle) Attack detection result. > Note: When using this parameter, only events with the `products.mitmAttack.data.result` property set to `true` or `false` are returned. Events without a `products.mitmAttack` Smart Signal result are left out of the response.  (optional) 
            var rareDevice = true;  // bool? | Filter events by Rare Device detection result. > Note: When using this parameter, only events with the `products.rareDevice.data.result` property set to `true` or `false` are returned. Events without a `products.rareDevice` Smart Signal result are left out of the response.  (optional) 
            var rareDevicePercentileBucket = rareDevicePercentileBucket_example;  // string | Filter events by Rare Device percentile bucket. `<p95` - device configuration is in the bottom 95% (most common). `p95-p99` - device is in the 95th to 99th percentile. `p99-p99.5` - device is in the 99th to 99.5th percentile. `p99.5-p99.9` - device is in the 99.5th to 99.9th percentile. `p99.9+` - device is in the top 0.1% (rarest). `not_seen` - device configuration has never been observed before.  (optional) 
            var proxy = true;  // bool? | Filter events by Proxy detection result. > Note: When using this parameter, only events with the `products.proxy.data.result` property set to `true` or `false` are returned. Events without a `products.proxy` Smart Signal result are left out of the response.  (optional) 
            var sdkVersion = sdkVersion_example;  // string | Filter events by a specific SDK version associated with the identification event. Example: `3.11.14`  (optional) 
            var sdkPlatform = sdkPlatform_example;  // string | Filter events by the SDK Platform associated with the identification event. `js` - JavaScript agent (Web). `ios` - Apple iOS based devices. `android` - Android based devices.  (optional) 
            var environment = new List<string>(); // List<string> | Filter for events by providing one or more environment IDs.  (optional) 
            var proximityId = proximityId_example;  // string | Filter events by the most precise Proximity ID provided by default. > Note: When using this parameter, only events with the `products.proximity.id` property matching the provided ID are returned. Events without a `products.proximity` result are left out of the response.  (optional) 
            var proximityPrecisionRadius = 56;  // int? | Filter events by Proximity Radius. > Note: When using this parameter, only events with the `products.proximity.precisionRadius` property set to a valid value are returned. Events without a `products.proximity` result are left out of the response.  (optional) 

            try
            {
                // Get events via search
                SearchEventsResponse result = apiInstance.SearchEvents(limit, paginationKey, visitorId, bot, ipAddress, linkedId, start, end, reverse, suspect, vpn, virtualMachine, tampering, antiDetectBrowser, incognito, privacySettings, jailbroken, frida, factoryReset, clonedApp, emulator, rootApps, vpnConfidence, minSuspectScore, ipBlocklist, datacenter, developerTools, locationSpoofing, mitmAttack, rareDevice, rareDevicePercentileBucket, proxy, sdkVersion, sdkPlatform, environment, proximityId, proximityPrecisionRadius);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FingerprintApi.SearchEvents: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **limit** | **int?**| Limit the number of events returned.  | 
 **paginationKey** | **string**| Use `pagination_key` to get the next page of results.  When more results are available (e.g., you requested up to 200 results for your search using `limit`, but there are more than 200 events total matching your request), the `paginationKey` top-level attribute is added to the response. The key corresponds to the `timestamp` of the last returned event. In the following request, use that value in the `pagination_key` parameter to get the next page of results:  1. First request, returning most recent 200 events: `GET api-base-url/events/search?limit=200` 2. Use `response.paginationKey` to get the next page of results: `GET api-base-url/events/search?limit=200&pagination_key=1740815825085`  | [optional] 
 **visitorId** | **string**| Unique [visitor identifier](https://dev.fingerprint.com/reference/get-function#visitorid) issued by Fingerprint Identification and all active Smart Signals. Filter for events matching this `visitor_id`.  | [optional] 
 **bot** | **string**| Filter events by the Bot Detection result, specifically:   `all` - events where any kind of bot was detected.   `good` - events where a good bot was detected.   `bad` - events where a bad bot was detected.   `none` - events where no bot was detected. > Note: When using this parameter, only events with the `products.botd.data.bot.result` property set to a valid value are returned. Events without a `products.botd` Smart Signal result are left out of the response.  | [optional] 
 **ipAddress** | **string**| Filter events by IP address range. The range can be as specific as a single IP (/32 for IPv4 or /128 for IPv6) All ip_address filters must use CIDR notation, for example, 10.0.0.0/24, 192.168.0.1/32  | [optional] 
 **linkedId** | **string**| Filter events by your custom identifier.  You can use [linked IDs](https://dev.fingerprint.com/reference/get-function#linkedid) to associate identification requests with your own identifier, for example, session ID, purchase ID, or transaction ID. You can then use this `linked_id` parameter to retrieve all events associated with your custom identifier.  | [optional] 
 **start** | **long?**| Filter events with a timestamp greater than the start time, in Unix time (milliseconds).  | [optional] 
 **end** | **long?**| Filter events with a timestamp smaller than the end time, in Unix time (milliseconds).  | [optional] 
 **reverse** | **bool?**| Sort events in reverse timestamp order.  | [optional] 
 **suspect** | **bool?**| Filter events previously tagged as suspicious via the [Update API](https://dev.fingerprint.com/reference/updateevent). > Note: When using this parameter, only events with the `suspect` property explicitly set to `true` or `false` are returned. Events with undefined `suspect` property are left out of the response.  | [optional] 
 **vpn** | **bool?**| Filter events by VPN Detection result. > Note: When using this parameter, only events with the `products.vpn.data.result` property set to `true` or `false` are returned. Events without a `products.vpn` Smart Signal result are left out of the response.  | [optional] 
 **virtualMachine** | **bool?**| Filter events by Virtual Machine Detection result. > Note: When using this parameter, only events with the `products.virtualMachine.data.result` property set to `true` or `false` are returned. Events without a `products.virtualMachine` Smart Signal result are left out of the response.  | [optional] 
 **tampering** | **bool?**| Filter events by Tampering Detection result. > Note: When using this parameter, only events with the `products.tampering.data.result` property set to `true` or `false` are returned. Events without a `products.tampering` Smart Signal result are left out of the response.  | [optional] 
 **antiDetectBrowser** | **bool?**| Filter events by Anti-detect Browser Detection result. > Note: When using this parameter, only events with the `products.tampering.data.antiDetectBrowser` property set to `true` or `false` are returned. Events without a `products.tampering` Smart Signal result are left out of the response.  | [optional] 
 **incognito** | **bool?**| Filter events by Browser Incognito Detection result. > Note: When using this parameter, only events with the `products.incognito.data.result` property set to `true` or `false` are returned. Events without a `products.incognito` Smart Signal result are left out of the response.  | [optional] 
 **privacySettings** | **bool?**| Filter events by Privacy Settings Detection result. > Note: When using this parameter, only events with the `products.privacySettings.data.result` property set to `true` or `false` are returned. Events without a `products.privacySettings` Smart Signal result are left out of the response.  | [optional] 
 **jailbroken** | **bool?**| Filter events by Jailbroken Device Detection result. > Note: When using this parameter, only events with the `products.jailbroken.data.result` property set to `true` or `false` are returned. Events without a `products.jailbroken` Smart Signal result are left out of the response.  | [optional] 
 **frida** | **bool?**| Filter events by Frida Detection result. > Note: When using this parameter, only events with the `products.frida.data.result` property set to `true` or `false` are returned. Events without a `products.frida` Smart Signal result are left out of the response.  | [optional] 
 **factoryReset** | **bool?**| Filter events by Factory Reset Detection result. > Note: When using this parameter, only events with the `products.factoryReset.data.result` property set to `true` or `false` are returned. Events without a `products.factoryReset` Smart Signal result are left out of the response.  | [optional] 
 **clonedApp** | **bool?**| Filter events by Cloned App Detection result. > Note: When using this parameter, only events with the `products.clonedApp.data.result` property set to `true` or `false` are returned. Events without a `products.clonedApp` Smart Signal result are left out of the response.  | [optional] 
 **emulator** | **bool?**| Filter events by Android Emulator Detection result. > Note: When using this parameter, only events with the `products.emulator.data.result` property set to `true` or `false` are returned. Events without a `products.emulator` Smart Signal result are left out of the response.  | [optional] 
 **rootApps** | **bool?**| Filter events by Rooted Device Detection result. > Note: When using this parameter, only events with the `products.rootApps.data.result` property set to `true` or `false` are returned. Events without a `products.rootApps` Smart Signal result are left out of the response.  | [optional] 
 **vpnConfidence** | **string**| Filter events by VPN Detection result confidence level. `high` - events with high VPN Detection confidence. `medium` - events with medium VPN Detection confidence. `low` - events with low VPN Detection confidence. > Note: When using this parameter, only events with the `products.vpn.data.confidence` property set to a valid value are returned. Events without a `products.vpn` Smart Signal result are left out of the response.  | [optional] 
 **minSuspectScore** | **float?**| Filter events with Suspect Score result above a provided minimum threshold. > Note: When using this parameter, only events where the `products.suspectScore.data.result` property set to a value exceeding your threshold are returned. Events without a `products.suspectScore` Smart Signal result are left out of the response.  | [optional] 
 **ipBlocklist** | **bool?**| Filter events by IP Blocklist Detection result. > Note: When using this parameter, only events with the `products.ipBlocklist.data.result` property set to `true` or `false` are returned. Events without a `products.ipBlocklist` Smart Signal result are left out of the response.  | [optional] 
 **datacenter** | **bool?**| Filter events by Datacenter Detection result. > Note: When using this parameter, only events with the `products.ipInfo.data.v4.datacenter.result` or `products.ipInfo.data.v6.datacenter.result` property set to `true` or `false` are returned. Events without a `products.ipInfo` Smart Signal result are left out of the response.  | [optional] 
 **developerTools** | **bool?**| Filter events by Developer Tools detection result. > Note: When using this parameter, only events with the `products.developerTools.data.result` property set to `true` or `false` are returned. Events without a `products.developerTools` Smart Signal result are left out of the response.  | [optional] 
 **locationSpoofing** | **bool?**| Filter events by Location Spoofing detection result. > Note: When using this parameter, only events with the `products.locationSpoofing.data.result` property set to `true` or `false` are returned. Events without a `products.locationSpoofing` Smart Signal result are left out of the response.  | [optional] 
 **mitmAttack** | **bool?**| Filter events by MITM (Man-in-the-Middle) Attack detection result. > Note: When using this parameter, only events with the `products.mitmAttack.data.result` property set to `true` or `false` are returned. Events without a `products.mitmAttack` Smart Signal result are left out of the response.  | [optional] 
 **rareDevice** | **bool?**| Filter events by Rare Device detection result. > Note: When using this parameter, only events with the `products.rareDevice.data.result` property set to `true` or `false` are returned. Events without a `products.rareDevice` Smart Signal result are left out of the response.  | [optional] 
 **rareDevicePercentileBucket** | **string**| Filter events by Rare Device percentile bucket. `<p95` - device configuration is in the bottom 95% (most common). `p95-p99` - device is in the 95th to 99th percentile. `p99-p99.5` - device is in the 99th to 99.5th percentile. `p99.5-p99.9` - device is in the 99.5th to 99.9th percentile. `p99.9+` - device is in the top 0.1% (rarest). `not_seen` - device configuration has never been observed before.  | [optional] 
 **proxy** | **bool?**| Filter events by Proxy detection result. > Note: When using this parameter, only events with the `products.proxy.data.result` property set to `true` or `false` are returned. Events without a `products.proxy` Smart Signal result are left out of the response.  | [optional] 
 **sdkVersion** | **string**| Filter events by a specific SDK version associated with the identification event. Example: `3.11.14`  | [optional] 
 **sdkPlatform** | **string**| Filter events by the SDK Platform associated with the identification event. `js` - JavaScript agent (Web). `ios` - Apple iOS based devices. `android` - Android based devices.  | [optional] 
 **environment** | [**List&lt;string&gt;**](string.md)| Filter for events by providing one or more environment IDs.  | [optional] 
 **proximityId** | **string**| Filter events by the most precise Proximity ID provided by default. > Note: When using this parameter, only events with the `products.proximity.id` property matching the provided ID are returned. Events without a `products.proximity` result are left out of the response.  | [optional] 
 **proximityPrecisionRadius** | **int?**| Filter events by Proximity Radius. > Note: When using this parameter, only events with the `products.proximity.precisionRadius` property set to a valid value are returned. Events without a `products.proximity` result are left out of the response.  | [optional] 

### Return type

[**SearchEventsResponse**](SearchEventsResponse.md)

### Authorization

[ApiKeyHeader](../README.md#ApiKeyHeader), [ApiKeyQuery](../README.md#ApiKeyQuery)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="updateevent"></a>
# **UpdateEvent**
> void UpdateEvent (EventsUpdateRequest body, string requestId)

Update an event with a given request ID

> 🚧 Deprecation Notice
>
> This version of Server API is marked as deprecated starting on **Jan 7th 2026** and will be fully removed on **Jan 7th 2027** according to our [API Deprecation Policy](https://dev.fingerprint.com/reference/api-deprecation-policy). If you still use this version, please follow our [migration guide](https://dev.fingerprint.com/reference/migrating-from-server-api-v3-to-v4#migrating-update-events) to migrate from this deprecated version to the new one.

Change information in existing events specified by `requestId` or *flag suspicious events*.

When an event is created, it is assigned `linkedId` and `tag` submitted through the JS agent parameters. This information might not be available on the client so the Server API allows for updating the attributes after the fact.

**Warning** It's not possible to update events older than 10 days.


### Example
```csharp
using System;
using System.Diagnostics;
using FingerprintPro.ServerSdk.Api;
using FingerprintPro.ServerSdk.Client;
using FingerprintPro.ServerSdk.Model;

namespace Example
{
    public class UpdateEventExample
    {
        public void main()
        {
            var configuration = new Configuration("YOUR_API_KEY");
            var apiInstance = new FingerprintApi(configuration);
            var body = new EventsUpdateRequest(); // EventsUpdateRequest | 
            var requestId = requestId_example;  // string | The unique event [identifier](https://dev.fingerprint.com/reference/get-function#requestid).

            try
            {
                // Update an event with a given request ID
                apiInstance.UpdateEvent(body, requestId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FingerprintApi.UpdateEvent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**EventsUpdateRequest**](EventsUpdateRequest.md)|  | 
 **requestId** | **string**| The unique event [identifier](https://dev.fingerprint.com/reference/get-function#requestid). | 

### Return type

void (empty response body)

### Authorization

[ApiKeyHeader](../README.md#ApiKeyHeader), [ApiKeyQuery](../README.md#ApiKeyQuery)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

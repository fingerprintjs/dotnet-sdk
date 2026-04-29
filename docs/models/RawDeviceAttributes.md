# Fingerprint.ServerSdk.Model.RawDeviceAttributes
A curated subset of raw browser/device attributes that the API surface exposes. Each property contains a value or object with the data for the collected signal.


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FontPreferences** | [**FontPreferences**](FontPreferences.md) |  | [optional] 
**Emoji** | [**Emoji**](Emoji.md) |  | [optional] 
**Fonts** | **List&lt;string&gt;** | List of fonts detected on the device. | [optional] 
**DeviceMemory** | **int** | Rounded amount of RAM (in gigabytes) reported by the browser. | [optional] 
**Timezone** | **string** | Timezone identifier detected on the client. | [optional] 
**Canvas** | [**Canvas**](Canvas.md) |  | [optional] 
**Languages** | **List&lt;List&lt;string&gt;&gt;** | Navigator languages reported by the agent including fallbacks. Each inner array represents ordered language preferences reported by different APIs. Available for both browsers and iOS devices  | [optional] 
**WebglExtensions** | [**WebGlExtensions**](WebGlExtensions.md) |  | [optional] 
**WebglBasics** | [**WebGlBasics**](WebGlBasics.md) |  | [optional] 
**ScreenResolution** | **List&lt;int&gt;** | Current screen resolution. Available for both browsers and iOS devices | [optional] 
**TouchSupport** | [**TouchSupport**](TouchSupport.md) |  | [optional] 
**Oscpu** | **string** | Navigator `oscpu` string. | [optional] 
**Architecture** | **int** | Integer representing the CPU architecture exposed by the browser. | [optional] 
**CookiesEnabled** | **bool** | Whether the cookies are enabled in the browser. | [optional] 
**HardwareConcurrency** | **int** | Number of logical CPU cores reported by the browser. | [optional] 
**DateTimeLocale** | **string** | Locale derived from the Intl.DateTimeFormat API. Negative values indicate known error states. The negative statuses can be: - \"-1\": A permanent status for browsers that don't support Intl API. - \"-2\": A permanent status for browsers that don't supportDateTimeFormat constructor. - \"-3\": A permanent status for browsers in which DateTimeFormat locale is undefined or null.  | [optional] 
**Vendor** | **string** | Navigator vendor string. | [optional] 
**ColorDepth** | **int** | Screen color depth in bits. | [optional] 
**Platform** | **string** | Navigator platform string. | [optional] 
**SessionStorage** | **bool** | Whether sessionStorage is available. | [optional] 
**LocalStorage** | **bool** | Whether localStorage is available. | [optional] 
**Audio** | **double** | AudioContext fingerprint or negative status when unavailable. The negative statuses can be: - -1: A permanent status for those browsers which are known to always suspend audio context - -2: A permanent status for browsers that don't support the signal - -3: A temporary status that means that an unexpected timeout has happened  | [optional] 
**Plugins** | [**List&lt;PluginsInner&gt;**](PluginsInner.md) | Browser plugins reported by `navigator.plugins`. | [optional] 
**IndexedDb** | **bool** | Whether IndexedDB is available. | [optional] 
**Math** | **string** | Hash of Math APIs used for entropy collection. | [optional] 
**DeviceModel** | **string** | Device model string. Available only for Android and iOS devices. | [optional] 
**DeviceManufacturer** | **string** | Device manufacturer string. Available only for Android and iOS devices. | [optional] 
**FontHash** | **string** | Unique identifier for the user’s installed fonts. | [optional] 
**TimezoneOffset** | **string** | UTC offset in \"±HH:MM\" format derived from the detected IANA timezone. | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)


# FingerprintPro.ServerSdk.Model.WebhookVPN
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Result** | **bool?** | VPN or other anonymizing service has been used when sending the request. | [optional] 
**Confidence** | **VPNConfidence** |  | [optional] 
**MlScore** | **double?** | Machine learning–based VPN score, represented as a floating-point value between 0 and 1 (inclusive), with up to three decimal places of precision. A higher score means a higher confidence in the positive `vpn` detection result. This Smart Signal is currently in beta and only available to select customers. If you are interested, please [contact our support team](https://fingerprint.com/support/).  | [optional] 
**OriginTimezone** | **string** | Local timezone which is used in timezoneMismatch method. | [optional] 
**OriginCountry** | **string** | Country of the request (only for Android SDK version >= 2.4.0, ISO 3166 format or unknown). | [optional] 
**Methods** | [**VPNMethods**](VPNMethods.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


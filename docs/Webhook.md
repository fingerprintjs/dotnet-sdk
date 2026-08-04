# FingerprintPro.ServerSdk.Model.Webhook
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RequestId** | **string** | Unique identifier of the user's request. | 
**Url** | **string** | Page URL from which the request was sent. | 
**Ip** | **string** | IP address of the requesting browser or bot. | 
**EnvironmentId** | **string** | Environment ID of the event. | [optional] 
**Tag** | [**Tag**](Tag.md) |  | [optional] 
**Time** | **DateTime?** | Time expressed according to ISO 8601 in UTC format, when the request from the JS agent was made. We recommend to treat requests that are older than 2 minutes as malicious. Otherwise, request replay attacks are possible. | 
**Timestamp** | **long?** | Timestamp of the event with millisecond precision in Unix time. | 
**IpLocation** | [**DeprecatedGeolocation**](DeprecatedGeolocation.md) |  | [optional] 
**LinkedId** | **string** | A customer-provided id that was sent with the request. | [optional] 
**VisitorId** | **string** | String of 20 characters that uniquely identifies the visitor's browser or mobile device. | [optional] 
**VisitorFound** | **bool?** | Attribute represents if a visitor had been identified before. | [optional] 
**Confidence** | [**IdentificationConfidence**](IdentificationConfidence.md) |  | [optional] 
**FirstSeenAt** | [**IdentificationSeenAt**](IdentificationSeenAt.md) |  | [optional] 
**LastSeenAt** | [**IdentificationSeenAt**](IdentificationSeenAt.md) |  | [optional] 
**BrowserDetails** | [**BrowserDetails**](BrowserDetails.md) |  | [optional] 
**Incognito** | **bool?** | Flag if user used incognito session. | [optional] 
**ClientReferrer** | **string** |  | [optional] 
**Components** | [**RawDeviceAttributes**](RawDeviceAttributes.md) |  | [optional] 
**Bot** | [**BotdBot**](BotdBot.md) |  | [optional] 
**UserAgent** | **string** |  | [optional] 
**RootApps** | [**WebhookRootApps**](WebhookRootApps.md) |  | [optional] 
**Emulator** | [**WebhookEmulator**](WebhookEmulator.md) |  | [optional] 
**IpInfo** | [**WebhookIPInfo**](WebhookIPInfo.md) |  | [optional] 
**IpBlocklist** | [**WebhookIPBlocklist**](WebhookIPBlocklist.md) |  | [optional] 
**Tor** | [**WebhookTor**](WebhookTor.md) |  | [optional] 
**Vpn** | [**WebhookVPN**](WebhookVPN.md) |  | [optional] 
**Proxy** | [**WebhookProxy**](WebhookProxy.md) |  | [optional] 
**Tampering** | [**WebhookTampering**](WebhookTampering.md) |  | [optional] 
**ClonedApp** | [**WebhookClonedApp**](WebhookClonedApp.md) |  | [optional] 
**FactoryReset** | [**WebhookFactoryReset**](WebhookFactoryReset.md) |  | [optional] 
**Jailbroken** | [**WebhookJailbroken**](WebhookJailbroken.md) |  | [optional] 
**Frida** | [**WebhookFrida**](WebhookFrida.md) |  | [optional] 
**PrivacySettings** | [**WebhookPrivacySettings**](WebhookPrivacySettings.md) |  | [optional] 
**VirtualMachine** | [**WebhookVirtualMachine**](WebhookVirtualMachine.md) |  | [optional] 
**RawDeviceAttributes** | [**WebhookRawDeviceAttributes**](WebhookRawDeviceAttributes.md) |  | [optional] 
**HighActivity** | [**WebhookHighActivity**](WebhookHighActivity.md) |  | [optional] 
**LocationSpoofing** | [**WebhookLocationSpoofing**](WebhookLocationSpoofing.md) |  | [optional] 
**SuspectScore** | [**WebhookSuspectScore**](WebhookSuspectScore.md) |  | [optional] 
**RemoteControl** | [**WebhookRemoteControl**](WebhookRemoteControl.md) |  | [optional] 
**Velocity** | [**WebhookVelocity**](WebhookVelocity.md) |  | [optional] 
**DeveloperTools** | [**WebhookDeveloperTools**](WebhookDeveloperTools.md) |  | [optional] 
**MitmAttack** | [**WebhookMitMAttack**](WebhookMitMAttack.md) |  | [optional] 
**RareDevice** | [**WebhookRareDevice**](WebhookRareDevice.md) |  | [optional] 
**Replayed** | **bool?** | `true` if we determined that this payload was replayed, `false` otherwise.  | [optional] 
**Sdk** | [**SDK**](SDK.md) |  | 
**SupplementaryIds** | [**WebhookSupplementaryIDs**](WebhookSupplementaryIDs.md) |  | [optional] 
**Proximity** | [**WebhookProximity**](WebhookProximity.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


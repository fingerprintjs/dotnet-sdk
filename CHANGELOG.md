# Fingerprint Server API Dotnet SDK

## 7.10.0

### Minor Changes

- ### SDK Changes ([bdcf7de](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/bdcf7def8039025d95e418936f3b47e824966844))

  - Add `WorkspaceScopedSecretKeyRequired` error code
  - Add optional `Type` field to `IPInfoASN` response model
  - Add `Integrations` field to `SDK` model with a list of `Integration` and `IntegrationSubIntegration`.

  ### Deprecation

  :warning: `FingerprintPro.ServerSdk` uses Server API v3, which is deprecated. Please migrate to the new
  [`Fingerprint.ServerSdk`](https://github.com/fingerprintjs/dotnet-sdk) package which uses Server API v4. ([bdcf7de](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/bdcf7def8039025d95e418936f3b47e824966844))

## 7.10.0-test.0

### Minor Changes

- **Deprecated:** `FingerprintPro.ServerSdk` uses Server API v3, which is deprecated. Please migrate to the new [`Fingerprint.ServerSdk`](https://github.com/fingerprintjs/dotnet-sdk) package which uses Server API v4. ([bdcf7de](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/bdcf7def8039025d95e418936f3b47e824966844))

## 7.9.0

### Minor Changes

- **events-search**: Event search now supports a new set of filter parameters: `developer_tools`, `location_spoofing`, `mitm_attack`, `proxy`, `sdk_version`, `sdk_platform`, `environment` ([f6036c2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/f6036c2f2da9a1c0878c55aa75eda8dc21abe5fd))
- **webhook**: Add `supplementaryIds` property to the Webhooks schema. ([f6036c2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/f6036c2f2da9a1c0878c55aa75eda8dc21abe5fd))
- Add `proximity` signal that represents a fixed geographical zone in a discrete global grid within which the device is observed. ([56e95c8](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/56e95c8889a27b8d4b9e852af079db42d0ae5d64))
- Add `environmentId` property to `identification` ([f6036c2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/f6036c2f2da9a1c0878c55aa75eda8dc21abe5fd))

## 7.9.0-test.1

### Minor Changes

- Add `proximity` signal that represents a fixed geographical zone in a discrete global grid within which the device is observed. ([56e95c8](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/56e95c8889a27b8d4b9e852af079db42d0ae5d64))

## 7.9.0-test.0

### Minor Changes

- **events-search**: Event search now supports a new set of filter parameters: `developer_tools`, `location_spoofing`, `mitm_attack`, `proxy`, `sdk_version`, `sdk_platform`, `environment` ([f6036c2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/f6036c2f2da9a1c0878c55aa75eda8dc21abe5fd))
- **webhook**: Add `supplementaryIds` property to the Webhooks schema. ([f6036c2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/f6036c2f2da9a1c0878c55aa75eda8dc21abe5fd))
- Add `environmentId` property to `identification` ([f6036c2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/f6036c2f2da9a1c0878c55aa75eda8dc21abe5fd))

## 7.8.0

### Minor Changes

- Add `details` object to the `proxy` signal. This field includes the `type` of the detected proxy (`residential` or `data_center`) and the `lastSeenAt` timestamp of when an IP was last observed to show proxy-like behavior. ([458455a](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/458455a9163085ae2a0325308c15a95ef6e19899))

## 7.7.0

### Minor Changes

- Mark `replayed` field required in the `identification` product schema. This field will always be present. ([9088e89](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9088e8942fbaa8aae4bebe75810cec2c0c18a4d7))
- Add `sdk` field with platform metadata to `identification` ([9088e89](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9088e8942fbaa8aae4bebe75810cec2c0c18a4d7))

### Patch Changes

- Deprecate the Remote Control Detection Smart Signal. This signal is no longer available. ([9088e89](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9088e8942fbaa8aae4bebe75810cec2c0c18a4d7))

## 7.7.0-test.0

### Minor Changes

- Mark `replayed` field required in the `identification` product schema. This field will always be present. ([9088e89](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9088e8942fbaa8aae4bebe75810cec2c0c18a4d7))
- Add `sdk` field with platform metadata to `identification` ([9088e89](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9088e8942fbaa8aae4bebe75810cec2c0c18a4d7))

### Patch Changes

- Deprecate the Remote Control Detection Smart Signal. This signal is no longer available. ([9088e89](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9088e8942fbaa8aae4bebe75810cec2c0c18a4d7))

## 7.6.0

### Minor Changes

- add `replayed` field to `identification` in Events and Webhooks ([0c6c173](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/0c6c173b943f38f36b9d3a419dbe7c3fc932ebbb))

## 7.5.0

### Minor Changes

- Add `confidence` property to the Proxy detection Smart Signal, which now supports both residential and public web proxies. ([2c63338](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/2c6333851112f4a274e2d338ac5198ce8ada8f94))

## 7.4.0

### Minor Changes

- **events-search**: Event search now supports a new set of filter parameters: `vpn`, `virtual_machine`, `tampering`, `anti_detect_browser`, `incognito`, `privacy_settings`, `jailbroken`, `frida`, `factory_reset`, `cloned_app`, `emulator`, `root_apps`, `vpn_confidence`, `min_suspect_score`. ([27fda6d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/27fda6d2ca5377d17efb5ccb99b691d5c1e3696b))
- **events-search**: Event search now supports two new filter parameters: `ip_blocklist`, `datacenter` ([7535359](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/75353590af9435c06db46c64ae50f01a453d7304))

### Patch Changes

- **events**: Update Tampering descriptions to reflect Android support. ([27fda6d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/27fda6d2ca5377d17efb5ccb99b691d5c1e3696b))
- **webhook**: Add `environmentId` property ([27fda6d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/27fda6d2ca5377d17efb5ccb99b691d5c1e3696b))

## 7.4.0-test.1

### Minor Changes

- **events-search**: Event search now supports two new filter parameters: `ip_blocklist`, `datacenter` ([7535359](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/75353590af9435c06db46c64ae50f01a453d7304))

## 7.4.0-test.0

### Minor Changes

- **events-search**: Event search now supports a new set of filter parameters: `vpn`, `virtual_machine`, `tampering`, `anti_detect_browser`, `incognito`, `privacy_settings`, `jailbroken`, `frida`, `factory_reset`, `cloned_app`, `emulator`, `root_apps`, `vpn_confidence`, `min_suspect_score`. ([27fda6d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/27fda6d2ca5377d17efb5ccb99b691d5c1e3696b))

### Patch Changes

- **events**: Update Tampering descriptions to reflect Android support. ([27fda6d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/27fda6d2ca5377d17efb5ccb99b691d5c1e3696b))
- **webhook**: Add `environmentId` property ([27fda6d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/27fda6d2ca5377d17efb5ccb99b691d5c1e3696b))

## 7.3.0

### Minor Changes

- Add `mitmAttack` (man-in-the-middle attack) Smart Signal. ([81b6d59](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/81b6d5901d764294cee959bc3a78db66967c1642))

## 7.2.0

### Minor Changes

- **events-search**: Add a new `events/search` API endpoint. Allow users to search for identification events matching one or more search criteria, for example, visitor ID, IP address, bot detection result, etc. ([0844a4e](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/0844a4e5c26abcb2a83ea2b0fbffdff96d836925))

## 7.2.0-test.1

### Minor Changes

- **events-search**: Add 'pagination_key' parameter ([2f38b0a](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/2f38b0a2b2ae1ee1d89f983d0cbaab3a5f0a4003))

### Patch Changes

- **events-search**: Improve parameter descriptions for `bot`, `suspect` ([e70bbb1](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/e70bbb1b2e42be8023609da12e330f12a743f437))

## 7.2.0-test.0

### Minor Changes

- **events-search**: Add a new `events/search` API endpoint. Allow users to search for identification events matching one or more search criteria, for example, visitor ID, IP address, bot detection result, etc. ([0844a4e](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/0844a4e5c26abcb2a83ea2b0fbffdff96d836925))

## 7.1.0

### Minor Changes

- Add `relay` detection method to the VPN Detection Smart Signal ([e5f305d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/e5f305d85c89ffaa63a42833275c75ac85553683))
- **events**: Add a `suspect` field to the `identification` product schema ([e5f305d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/e5f305d85c89ffaa63a42833275c75ac85553683))

## 7.0.0

### Major Changes

The underlying Server API hasn’t changed, but we made SDK type and class generation more precise, resulting in small breaking changes for the SDK itself. This change should make the SDK API a lot more stable going forward

- Replace `ProductError.CodeEnum` and `IdentificationError.CodeEnum` with `ErrorCode` ([32afba9](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/32afba9e669a6a4b891a0fbe70bae0c53e8f5788))
- - Remove the `BrowserDetails` field `botProbability`.
  - Update the `IdentificationConfidence` field `score` type format: `float` -> `double`.
  - Make the `RawDeviceAttributeError` field `name` **optional** .
  - Make the `RawDeviceAttributeError` field `message` **optional** .
  - **events**: Remove the `EventsResponse` field `error`.
    - [note]: The errors are represented by `ErrorResponse` model.
  - **events**: Update the `HighActivity` field `dailyRequests` type format: `number` -> `int64`.
  - **events**: Specify the `Tampering` field `anomalyScore` type format: `double`.
  - **webhook**: Make the `Webhook` fields **optional**: `visitorId`, `visitorFound`, `firstSeenAt`, `lastSeenAt`, `browserDetails`, `incognito`.
  - **webhook**: Make the `WebhookClonedApp` field `result` **optional**.
  - **webhook**: Make the `WebhookDeveloperTools` field `result` **optional**.
  - **webhook**: Make the `WebhookEmulator` field `result` **optional**.
  - **webhook**: Make the `WebhookFactoryReset` fields `time` and `timestamp` **optional**.
  - **webhook**: Make the `WebhookFrida` field `result` **optional**.
  - **webhook**: Update the `WebhookHighActivity` field `dailyRequests` type format: `number` -> `int64`.
  - **webhook**: Make the `WebhookIPBlocklist` fields `result` and `details` **optional**.
  - **webhook**: Make the `WebhookJailbroken` field `result` **optional**.
  - **webhook**: Make the `WebhookLocationSpoofing` field `result` **optional**.
  - **webhook**: Make the `WebhookPrivacySettings` field `result` **optional**.
  - **webhook**: Make the `WebhookProxy` field `result` **optional**.
  - **webhook**: Make the `WebhookRemoteControl` field `result` **optional**.
  - **webhook**: Make the `WebhookRootApps` field `result` **optional**.
  - **webhook**: Make the `WebhookSuspectScore` field `result` **optional**.
  - **webhook**: Make the `WebhookTampering` fields `result`, `anomalyScore` and `antiDetectBrowser` **optional**.
  - **webhook**: Specify the `WebhookTampering` field `anomalyScore` type format: `double`.
  - **webhook**: Make the `WebhookTor` field `result` **optional**.
  - **webhook**: Make the `WebhookVelocity` fields **optional**: `distinctIp`, `distinctLinkedId`, `distinctCountry`, `events`, `ipEvents`, `distinctIpByLinkedId`, `distinctVisitorIdByLinkedId`.
  - **webhook**: Make the `WebhookVirtualMachine` field `result` **optional**.
  - **webhook**: Make the `WebhookVPN` fields **optional**: `result`, `confidence`, `originTimezone`, `methods`. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- Rename errors models related to visits:
  - rename `ErrorVisitsDelete400Response` to `ErrorVisitor400Response`
  - rename `ErrorVisitsDelete404ResponseError` to `ErrorVisitor404ResponseError`
  - rename `ErrorVisitsDelete404Response` to `ErrorVisitor404Response` ([c32807b](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/c32807b8cf88cbddf5167763f20ee2dbfd1117a2))
- Rename `IsValidWebhookSignature` to `IsValidSignature` in `WebhookValidation` ([a8058e2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a8058e29f70206f387271fbcd9c3b810a867c414))
- - Rename `BotdResult` -> `Botd`.
  - Rename `BotdDetectionResult` -> `BotdBot`:
    - Extract `result` type as `BotdBotResult`.
  - Rename `ClonedAppResult` -> `ClonedApp`.
  - Rename `DeveloperToolsResult` -> `DeveloperTools`.
  - Rename `EmulatorResult` -> `Emulator`.
  - Refactor error models:
    - Remove `ErrorCommon403Response`, `ErrorCommon429Response`, `ErrorEvent404Response`, `TooManyRequestsResponse`, `ErrorVisits403`, `ErrorUpdateEvent400Response`, `ErrorUpdateEvent409Response`, `ErrorVisitor400Response`, `ErrorVisitor404Response`, `IdentificationError`, `ProductError`.
    - Introduce `ErrorResponse` and `ErrorPlainResponse`.
      - [note]: `ErrorPlainResponse` has a different format `{ "error": string }` and it is used only in `GET /visitors`.
    - Extract `error` type as `Error`.
    - Extract `error.code` type as `ErrorCode`.
  - Rename `EventResponse` -> `EventsGetResponse`.
  - Rename `EventUpdateRequest` -> `EventsUpdateRequest`.
  - Rename `FactoryResetResult` -> `FactoryReset`.
  - Rename `FridaResult` -> `Frida`.
  - Rename `IPLocation` -> `Geolocation`:
    - Rename `IPLocationCity` -> `GeolocationCity`.
    - Extract `subdivisions` type as `GeolocationSubdivisions`.
    - Rename `Location` -> `GeolocationContinent`:
    - Introduce a dedicated type `GeolocationCountry`.
    - Rename `Subdivision` -> `GeolocationSubdivision`.
  - Rename `HighActivityResult` -> `HighActivity`.
  - Rename `Confidence` -> `IdentificationConfidence`.
  - Rename `SeenAt` -> `IdentificationSeenAt`.
  - Rename `IncognitoResult` -> `Incognito`.
  - Rename `IpBlockListResult` -> `IPBlocklist`:
    - Extract `details` type as `IPBlocklistDetails`.
  - Rename `IpInfoResult` -> `IPInfo`:
    - Rename `IpInfoResultV4` -> `IPInfoV4`.
    - Rename `IpInfoResultV6` -> `IPInfoV6`.
    - Rename `ASN` -> `IPInfoASN`.
    - Rename `DataCenter` -> `IPInfoDataCenter`.
  - Rename `JailbrokenResult` -> `Jailbroken`.
  - Rename `LocationSpoofingResult` -> `LocationSpoofing`.
  - Rename `PrivacySettingsResult` -> `PrivacySettings`.
  - Rename `ProductsResponse` -> `Products`:
    - Rename inner types: `ProductsResponseIdentification` -> `ProductIdentification`, `ProductsResponseIdentificationData` -> `Identification`, `ProductsResponseBotd` -> `ProductBotd`, `SignalResponseRootApps` -> `ProductRootApps`, `SignalResponseEmulator` -> `ProductEmulator`, `SignalResponseIpInfo` -> `ProductIPInfo`, `SignalResponseIpBlocklist` -> `ProductIPBlocklist`, `SignalResponseTor` -> `ProductTor`, `SignalResponseVpn` -> `ProductVPN`, `SignalResponseProxy` -> `ProductProxy`, `ProxyResult` -> `Proxy`, `SignalResponseIncognito` -> `ProductIncognito`, `SignalResponseTampering` -> `ProductTampering`, `SignalResponseClonedApp` -> `ProductClonedApp`, `SignalResponseFactoryReset` -> `ProductFactoryReset`, `SignalResponseJailbroken` -> `ProductJailbroken`, `SignalResponseFrida` -> `ProductFrida`, `SignalResponsePrivacySettings` -> `ProductPrivacySettings`, `SignalResponseVirtualMachine` -> `ProductVirtualMachine`, `SignalResponseRawDeviceAttributes` -> `ProductRawDeviceAttributes`, `RawDeviceAttributesResultValue` -> `RawDeviceAttributes`, `SignalResponseHighActivity` -> `ProductHighActivity`, `SignalResponseLocationSpoofing` -> `ProductLocationSpoofing`, `SignalResponseSuspectScore` -> `ProductSuspectScore`, `SignalResponseRemoteControl` -> `ProductRemoteControl`, `SignalResponseVelocity` -> `ProductVelocity`, `SignalResponseDeveloperTools` -> `ProductDeveloperTools`.
    - Extract `identification.data` type as `Identification`.
  - Rename `RawDeviceAttributesResult` -> `RawDeviceAttributes`:
    - Extract item type as `RawDeviceAttribute`.
    - Extract `error` type as `RawDeviceAttributeError`.
  - Rename `RemoteControlResult` -> `RemoteControl`.
  - Rename `RootAppsResult` -> `RootApps`.
  - Rename `SuspectScoreResult` -> `SuspectScore`.
  - Extract new model `Tag`.
  - Rename `TamperingResult` -> `Tampering`.
  - Rename `TorResult` -> `Tor`.
  - Rename `VelocityResult` -> `Velocity`:
    - Rename `VelocityIntervals` -> `VelocityData`.
    - Rename `VelocityIntervalResult` -> `VelocityIntervals`.
  - Rename `VirtualMachineResult` -> `VirtualMachine`.
  - Rename the `Visit` field `ipLocation` type `DeprecatedIPLocation` -> `DeprecatedGeolocation`.
    - Instead of `DeprecatedIPLocationCity` use common `GeolocationCity`
  - Rename `Response` -> `VisitorsGetResponse`.
    - Omit extra inner type `ResponseVisits`
  - Rename `VpnResult` -> `VPN`.
    - Extract `confidence` type as `VPNConfidence`.
    - Extract `methods` type as `VPNMethods`.
  - Rename `WebhookVisit` -> `Webhook`.
    - Introduce new inner types: `WebhookRootApps`, `WebhookEmulator`, `WebhookIPInfo`, `WebhookIPBlocklist`, `WebhookTor`, `WebhookVPN`, `WebhookProxy`, `WebhookTampering`, `WebhookClonedApp`, `WebhookFactoryReset`, `WebhookJailbroken`, `WebhookFrida`, `WebhookPrivacySettings`, `WebhookVirtualMachine`, `WebhookRawDeviceAttributes`, `WebhookHighActivity`, `WebhookLocationSpoofing`, `WebhookSuspectScore`, `WebhookRemoteControl`, `WebhookVelocity`, `WebhookDeveloperTools`. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- Drop support for .NET6 and .NET7 because they reached EOL ([d9febcb](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/d9febcb2fcac9d57f8ca7e70d3157e1358bcf900))
- Store `ErrorCode` enum in `ErrorCode` property in `ApiException`. Http code in now available in `HttpCode` property. ([d197f29](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/d197f291249316108f3b4306989992187ce89bb4))
- Rename `Webhook` class to `WebhookValidation`.
  Right now, `Webhook` class points to the actual data model. ([77e0c16](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/77e0c166b11935e5a29ee5a320eba097f910e355))
- Expose actual error message in `ApiException.Message` if available ([d197f29](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/d197f291249316108f3b4306989992187ce89bb4))

### Minor Changes

- Update System.Text.Json to 8.0.5 ([606c84a](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/606c84a1b8220ffdd8256eb7407d2bc440e2cd89))
- **related-visitors**: Add GET `/related-visitors` endpoint ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))
- Added new `ipEvents`, `distinctIpByLinkedId`, and `distinctVisitorIdByLinkedId` fields to the `velocity` Smart Signal. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- - Make the `GeolocationCity` field `name` **required**.
  - Make the `GeolocationSubdivision` field `isoCode` **required**.
  - Make the `GeolocationSubdivision` field `name` **required**.
  - Make the `IPInfoASN` field `name` **required** .
  - Make the `IPInfoDataCenter` field `name` **required**.
  - Add **optional** `IdentificationConfidence` field `comment`.
  - **events**: Add **optional** `Botd` field `meta`.
  - **events**: Add **optional** `Identification` field `components`.
  - **events**: Make the `VPN` field `originCountry` **required**.
  - **visitors**: Add **optional** `Visit` field `components`.
  - **webhook**: Add **optional** `Webhook` field `components`. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- **visitors**: Add the confidence field to the VPN Detection Smart Signal ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))
- Remove `ipv4` format from `ip` field in `Botd`, `Identification`, `Visit` and `Webhook` models. ([0cceba7](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/0cceba71ae867f8740175164bff7a4a4bd07b719))
- **events**: Add `antiDetectBrowser` detection method to the `tampering` Smart Signal. ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))
- **events**: Introduce `PUT` endpoint for `/events` API ([b2c086c](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/b2c086c6855de802ba4b06d5b23e096dba288885))

### Patch Changes

- **related-visitors**: Add mention that the API is billable ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))

## 7.0.0-test.1

### Major Changes

- Replace `ProductError.CodeEnum` and `IdentificationError.CodeEnum` with `ErrorCode` ([32afba9](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/32afba9e669a6a4b891a0fbe70bae0c53e8f5788))
- - Remove the `BrowserDetails` field `botProbability`.
  - Update the `IdentificationConfidence` field `score` type format: `float` -> `double`.
  - Make the `RawDeviceAttributeError` field `name` **optional** .
  - Make the `RawDeviceAttributeError` field `message` **optional** .
  - **events**: Remove the `EventsResponse` field `error`.
    - [note]: The errors are represented by `ErrorResponse` model.
  - **events**: Update the `HighActivity` field `dailyRequests` type format: `number` -> `int64`.
  - **events**: Specify the `Tampering` field `anomalyScore` type format: `double`.
  - **webhook**: Make the `Webhook` fields **optional**: `visitorId`, `visitorFound`, `firstSeenAt`, `lastSeenAt`, `browserDetails`, `incognito`.
  - **webhook**: Make the `WebhookClonedApp` field `result` **optional**.
  - **webhook**: Make the `WebhookDeveloperTools` field `result` **optional**.
  - **webhook**: Make the `WebhookEmulator` field `result` **optional**.
  - **webhook**: Make the `WebhookFactoryReset` fields `time` and `timestamp` **optional**.
  - **webhook**: Make the `WebhookFrida` field `result` **optional**.
  - **webhook**: Update the `WebhookHighActivity` field `dailyRequests` type format: `number` -> `int64`.
  - **webhook**: Make the `WebhookIPBlocklist` fields `result` and `details` **optional**.
  - **webhook**: Make the `WebhookJailbroken` field `result` **optional**.
  - **webhook**: Make the `WebhookLocationSpoofing` field `result` **optional**.
  - **webhook**: Make the `WebhookPrivacySettings` field `result` **optional**.
  - **webhook**: Make the `WebhookProxy` field `result` **optional**.
  - **webhook**: Make the `WebhookRemoteControl` field `result` **optional**.
  - **webhook**: Make the `WebhookRootApps` field `result` **optional**.
  - **webhook**: Make the `WebhookSuspectScore` field `result` **optional**.
  - **webhook**: Make the `WebhookTampering` fields `result`, `anomalyScore` and `antiDetectBrowser` **optional**.
  - **webhook**: Specify the `WebhookTampering` field `anomalyScore` type format: `double`.
  - **webhook**: Make the `WebhookTor` field `result` **optional**.
  - **webhook**: Make the `WebhookVelocity` fields **optional**: `distinctIp`, `distinctLinkedId`, `distinctCountry`, `events`, `ipEvents`, `distinctIpByLinkedId`, `distinctVisitorIdByLinkedId`.
  - **webhook**: Make the `WebhookVirtualMachine` field `result` **optional**.
  - **webhook**: Make the `WebhookVPN` fields **optional**: `result`, `confidence`, `originTimezone`, `methods`. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- Rename `IsValidWebhookSignature` to `IsValidSignature` in `WebhookValidation` ([a8058e2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a8058e29f70206f387271fbcd9c3b810a867c414))
- - Rename `BotdResult` -> `Botd`.
  - Rename `BotdDetectionResult` -> `BotdBot`:
    - Extract `result` type as `BotdBotResult`.
  - Rename `ClonedAppResult` -> `ClonedApp`.
  - Rename `DeveloperToolsResult` -> `DeveloperTools`.
  - Rename `EmulatorResult` -> `Emulator`.
  - Refactor error models:
    - Remove `ErrorCommon403Response`, `ErrorCommon429Response`, `ErrorEvent404Response`, `TooManyRequestsResponse`, `ErrorVisits403`, `ErrorUpdateEvent400Response`, `ErrorUpdateEvent409Response`, `ErrorVisitor400Response`, `ErrorVisitor404Response`, `IdentificationError`, `ProductError`.
    - Introduce `ErrorResponse` and `ErrorPlainResponse`.
      - [note]: `ErrorPlainResponse` has a different format `{ "error": string }` and it is used only in `GET /visitors`.
    - Extract `error` type as `Error`.
    - Extract `error.code` type as `ErrorCode`.
  - Rename `EventResponse` -> `EventsGetResponse`.
  - Rename `EventUpdateRequest` -> `EventsUpdateRequest`.
  - Rename `FactoryResetResult` -> `FactoryReset`.
  - Rename `FridaResult` -> `Frida`.
  - Rename `IPLocation` -> `Geolocation`:
    - Rename `IPLocationCity` -> `GeolocationCity`.
    - Extract `subdivisions` type as `GeolocationSubdivisions`.
    - Rename `Location` -> `GeolocationContinent`:
    - Introduce a dedicated type `GeolocationCountry`.
    - Rename `Subdivision` -> `GeolocationSubdivision`.
  - Rename `HighActivityResult` -> `HighActivity`.
  - Rename `Confidence` -> `IdentificationConfidence`.
  - Rename `SeenAt` -> `IdentificationSeenAt`.
  - Rename `IncognitoResult` -> `Incognito`.
  - Rename `IpBlockListResult` -> `IPBlocklist`:
    - Extract `details` type as `IPBlocklistDetails`.
  - Rename `IpInfoResult` -> `IPInfo`:
    - Rename `IpInfoResultV4` -> `IPInfoV4`.
    - Rename `IpInfoResultV6` -> `IPInfoV6`.
    - Rename `ASN` -> `IPInfoASN`.
    - Rename `DataCenter` -> `IPInfoDataCenter`.
  - Rename `JailbrokenResult` -> `Jailbroken`.
  - Rename `LocationSpoofingResult` -> `LocationSpoofing`.
  - Rename `PrivacySettingsResult` -> `PrivacySettings`.
  - Rename `ProductsResponse` -> `Products`:
    - Rename inner types: `ProductsResponseIdentification` -> `ProductIdentification`, `ProductsResponseIdentificationData` -> `Identification`, `ProductsResponseBotd` -> `ProductBotd`, `SignalResponseRootApps` -> `ProductRootApps`, `SignalResponseEmulator` -> `ProductEmulator`, `SignalResponseIpInfo` -> `ProductIPInfo`, `SignalResponseIpBlocklist` -> `ProductIPBlocklist`, `SignalResponseTor` -> `ProductTor`, `SignalResponseVpn` -> `ProductVPN`, `SignalResponseProxy` -> `ProductProxy`, `ProxyResult` -> `Proxy`, `SignalResponseIncognito` -> `ProductIncognito`, `SignalResponseTampering` -> `ProductTampering`, `SignalResponseClonedApp` -> `ProductClonedApp`, `SignalResponseFactoryReset` -> `ProductFactoryReset`, `SignalResponseJailbroken` -> `ProductJailbroken`, `SignalResponseFrida` -> `ProductFrida`, `SignalResponsePrivacySettings` -> `ProductPrivacySettings`, `SignalResponseVirtualMachine` -> `ProductVirtualMachine`, `SignalResponseRawDeviceAttributes` -> `ProductRawDeviceAttributes`, `RawDeviceAttributesResultValue` -> `RawDeviceAttributes`, `SignalResponseHighActivity` -> `ProductHighActivity`, `SignalResponseLocationSpoofing` -> `ProductLocationSpoofing`, `SignalResponseSuspectScore` -> `ProductSuspectScore`, `SignalResponseRemoteControl` -> `ProductRemoteControl`, `SignalResponseVelocity` -> `ProductVelocity`, `SignalResponseDeveloperTools` -> `ProductDeveloperTools`.
    - Extract `identification.data` type as `Identification`.
  - Rename `RawDeviceAttributesResult` -> `RawDeviceAttributes`:
    - Extract item type as `RawDeviceAttribute`.
    - Extract `error` type as `RawDeviceAttributeError`.
  - Rename `RemoteControlResult` -> `RemoteControl`.
  - Rename `RootAppsResult` -> `RootApps`.
  - Rename `SuspectScoreResult` -> `SuspectScore`.
  - Extract new model `Tag`.
  - Rename `TamperingResult` -> `Tampering`.
  - Rename `TorResult` -> `Tor`.
  - Rename `VelocityResult` -> `Velocity`:
    - Rename `VelocityIntervals` -> `VelocityData`.
    - Rename `VelocityIntervalResult` -> `VelocityIntervals`.
  - Rename `VirtualMachineResult` -> `VirtualMachine`.
  - Rename the `Visit` field `ipLocation` type `DeprecatedIPLocation` -> `DeprecatedGeolocation`.
    - Instead of `DeprecatedIPLocationCity` use common `GeolocationCity`
  - Rename `Response` -> `VisitorsGetResponse`.
    - Omit extra inner type `ResponseVisits`
  - Rename `VpnResult` -> `VPN`.
    - Extract `confidence` type as `VPNConfidence`.
    - Extract `methods` type as `VPNMethods`.
  - Rename `WebhookVisit` -> `Webhook`.
    - Introduce new inner types: `WebhookRootApps`, `WebhookEmulator`, `WebhookIPInfo`, `WebhookIPBlocklist`, `WebhookTor`, `WebhookVPN`, `WebhookProxy`, `WebhookTampering`, `WebhookClonedApp`, `WebhookFactoryReset`, `WebhookJailbroken`, `WebhookFrida`, `WebhookPrivacySettings`, `WebhookVirtualMachine`, `WebhookRawDeviceAttributes`, `WebhookHighActivity`, `WebhookLocationSpoofing`, `WebhookSuspectScore`, `WebhookRemoteControl`, `WebhookVelocity`, `WebhookDeveloperTools`. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- Drop support for .NET6 and .NET7 because they reached EOL ([d9febcb](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/d9febcb2fcac9d57f8ca7e70d3157e1358bcf900))
- Store `ErrorCode` enum in `ErrorCode` property in `ApiException`. Http code in now available in `HttpCode` property. ([d197f29](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/d197f291249316108f3b4306989992187ce89bb4))
- Rename `Webhook` class to `WebhookValidation`.
  Right now, `Webhook` class points to the actual data model. ([77e0c16](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/77e0c166b11935e5a29ee5a320eba097f910e355))
- Expose actual error message in `ApiException.Message` if available ([d197f29](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/d197f291249316108f3b4306989992187ce89bb4))

### Minor Changes

- Update System.Text.Json to 8.0.5 ([606c84a](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/606c84a1b8220ffdd8256eb7407d2bc440e2cd89))
- **related-visitors**: Add GET `/related-visitors` endpoint ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))
- Added new `ipEvents`, `distinctIpByLinkedId`, and `distinctVisitorIdByLinkedId` fields to the `velocity` Smart Signal. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- - Make the `GeolocationCity` field `name` **required**.
  - Make the `GeolocationSubdivision` field `isoCode` **required**.
  - Make the `GeolocationSubdivision` field `name` **required**.
  - Make the `IPInfoASN` field `name` **required** .
  - Make the `IPInfoDataCenter` field `name` **required**.
  - Add **optional** `IdentificationConfidence` field `comment`.
  - **events**: Add **optional** `Botd` field `meta`.
  - **events**: Add **optional** `Identification` field `components`.
  - **events**: Make the `VPN` field `originCountry` **required**.
  - **visitors**: Add **optional** `Visit` field `components`.
  - **webhook**: Add **optional** `Webhook` field `components`. ([9400768](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/940076842e436eee0e8ffb9d4fdbab6c2d047f98))
- **visitors**: Add the confidence field to the VPN Detection Smart Signal ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))
- Remove `ipv4` format from `ip` field in `Botd`, `Identification`, `Visit` and `Webhook` models. ([0cceba7](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/0cceba71ae867f8740175164bff7a4a4bd07b719))
- **events**: Add `antiDetectBrowser` detection method to the `tampering` Smart Signal. ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))

### Patch Changes

- **related-visitors**: Add mention that the API is billable ([36ed522](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36ed52298896cd0f52edc4b707fa88e4a35e8b81))

## 7.0.0-test.0

### Major Changes

- Rename errors models related to visits:
  - rename `ErrorVisitsDelete400Response` to `ErrorVisitor400Response`
  - rename `ErrorVisitsDelete404ResponseError` to `ErrorVisitor404ResponseError`
  - rename `ErrorVisitsDelete404Response` to `ErrorVisitor404Response` ([c32807b](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/c32807b8cf88cbddf5167763f20ee2dbfd1117a2))

### Minor Changes

- **events**: Introduce `PUT` endpoint for `/events` API ([b2c086c](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/b2c086c6855de802ba4b06d5b23e096dba288885))

## [6.2.2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v6.2.1...v6.2.2) (2024-09-17)

### Bug Fixes

- fallback to `Configuration.BasePath` it `HttpClient` is provided with null `BaseAddress` ([1c69113](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/1c69113b3681f3981855ab265e92b75efda6e59e))

## [6.2.1](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v6.2.0...v6.2.1) (2024-09-16)

### Bug Fixes

- avoid making direct changes to passed `HttpClient` ([cee0146](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/cee014606538fe6e97b1e661aa9a187ee1122f5b))
- correctly pass `Configuration.Timeout` when creating `HttpClient` ([4edd39a](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/4edd39a7766e19ce81b52ce09225d3d07e84ca80))

## [6.2.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v6.1.0...v6.2.0) (2024-09-12)

### Features

- introduce `HttpClient` parameter to the `Configuration` ([41dafb3](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/41dafb3d083903991d89b7c48a5e08a772cef5b2))

### Bug Fixes

- correctly set default headers in HttpClient using `Configuration.DefaultHeader` ([b057874](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/b057874e711287438b43e1cf3e10c9f0eeb39a05))

## [6.1.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v6.0.2...v6.1.0) (2024-08-05)

### Features

- add `remoteControl`, `velocity` and `developerTools` signals ([cb04c99](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/cb04c99e0f5996065a7ec55879655e06ed830fc9))

### Bug Fixes

- make `tag` field optional for Webhook ([acae9de](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/acae9deb39c4eb10a13dd716f79539483188b90a))

## [6.0.2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v6.0.1...v6.0.2) (2024-07-10)

### Build System

- **deps:** update System.Text.Json to 8.0.4 ([2c4939b](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/2c4939b802da029ebfb0f7f5603a23e58eebcc3d))

## [6.0.1](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v6.0.0...v6.0.1) (2024-06-28)

### Bug Fixes

- remove usage of Newtonsoft.Json in `Sealed` class ([25a26ed](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/25a26ed4a1ec07f10367a7b4779c7d8daad76791))

### Build System

- **deps:** update BouncyCastle.Cryptography to 2.4.0 ([a1d63ba](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a1d63babe74d38bbc11987bccd46d65858971c01))

## [6.0.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v5.0.0...v6.0.0) (2024-06-28)

### ⚠ BREAKING CHANGES

- rename `ManyRequestsResponse` to `TooManyRequestsResponse`
- drop support for netcoreapp3.1 and older,

### Features

- add `Webhook.IsValidWebhookSignature` function for validating webhook signature ([7b4a7fb](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/7b4a7fb952af3837ed82fc4adf675dc9a20a7e29))
- add DELETE API ([6a457b7](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/6a457b7ccfe7a888a9ca4fa6933c6f0366ba20ae))
- add os Mismatch ([85ec77b](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/85ec77b49069ba7419e706f2a801f441ae9b78cf))
- add revision string field to confidence object ([d2af0ac](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/d2af0ac90467b24061ecf85c9470d08ecc02463a))
- drop support for frameworks that reached EOL ([a39d863](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a39d8639ead451792361ba235dc361ae255ada56))
- migrate swagger generated code in request logic to manual implementation ([b7e60c0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/b7e60c0e6928a7da200e7ed2a028b17fbe1ad92c))
- remove usage of Newtonsoft.Json and RestSharp ([77eed3d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/77eed3dc79fb9e8ed73095f83023e94180b67eab))
- rename `ManyRequestsResponse` to `TooManyRequestsResponse` ([8eae642](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/8eae642de09e55383794162ecbc91ff80b5bd263))

### Bug Fixes

- add `JsonDeserializeException` when json deserialization fails ([7aab037](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/7aab037d6c0aae76bf546a223b682bb74d9ff1b5))
- use correct error type for `incognito`, `rawDeviceAttributes` and `tampering` in the `GetEvent` method ([4b4120e](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/4b4120e812e9c4aa9a948e40ce5c25a626156c73))

### Documentation

- **README:** mention how to access raw HTTP response ([fd324e1](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/fd324e1d82ba700f26672dd09694698c5bf63db0))
- **README:** remove dependencies section ([9d7ae2a](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9d7ae2af56f13bec54d4f952345b2eb7fdec7209))

## [5.0.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v4.0.0...v5.0.0) (2024-03-28)

### ⚠ BREAKING CHANGES

- now only .NET >= 6 is supported

### Features

- add .net v8 ([56959dc](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/56959dc3e320007d79a831c8b798a188806ba226))
- drop support for .NET 5 ([866042e](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/866042e303accc528452bb81bdb0e49d7035c2b6))
- drop support for .NET 5 ([a402975](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a402975e576e4f531238fc846e78a313d95be520))

## [4.0.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v3.1.0...v4.0.0) (2024-03-18)

### ⚠ BREAKING CHANGES

- make identification field `confidence` optional
- deprecated `ipLocation` field uses `DeprecatedIpLocation` model
- change models for the most smart signals

### Features

- add `linkedId` field to the `BotdResult` type ([cddcd3c](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/cddcd3c97c15b4699bf3fe10bff5a5b42194d32b))
- add `originCountry` field to the `vpn` signal ([a8d9c42](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a8d9c426bbdd6cf901f458815a43d1fdf8f68cf8))
- add `SuspectScore` smart signal support ([36bcf07](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/36bcf0748fc1ee7a9b54453afd60b225e3d3a8df))
- fix `ipLocation` deprecation ([ca56d40](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/ca56d40d0c9a45c9c2a9e90a9dd92a2eb198a02b))
- make identification field `tag` required ([a2ba563](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a2ba563a9e5a04f2251860a964ec7b0a5a36fb49))
- use shared structures for webhooks and event ([a0adeff](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a0adeff17f903731be6460a4f3f5c9c0755ff31a))

### Bug Fixes

- make fields required according to real API response ([461797e](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/461797e4a9fa01ae13d68f444acfe4b82d90de7c))

## [3.1.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v3.0.0...v3.1.0) (2024-02-13)

### Features

- add method for decoding sealed results ([763b940](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/763b940c1ee6bc35ac45b1a9384736d8d6312431))

## [3.0.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.4.0...v3.0.0) (2024-01-12)

### ⚠ BREAKING CHANGES

- `IpInfo` field `DataCenter` renamed to `Datacenter`

### Features

- deprecate `IPLocation` ([0ffeeb9](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/0ffeeb9b6f35dd43ca88e8580b40cc6e795a06f9))
- use datacenter instead of the wrong dataCenter ([308b5e2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/308b5e263028c0e366e0f616d83a2e9e0e1f953a))

## [2.4.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.3.2...v2.4.0) (2023-11-23)

### Features

- add `highActivity` and `locationSpoofing` signals, support `originTimezone` for `vpn` signal ([8f80f28](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/8f80f2807337dc961982da5a26009bd6b772ca10))

## [2.3.2](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.3.1...v2.3.2) (2023-10-20)

### Bug Fixes

- change package author to Fingerprint ([721e91c](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/721e91ccf3494aa146bfc4aeabe870a86c7df0bc))

### Documentation

- **README:** add requirements and license mention INTER-283 ([0caaccc](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/0caaccc7e7d588bd11ececd52b9cf79cd85c63ce))

## [2.3.1](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.3.0...v2.3.1) (2023-09-25)

### Bug Fixes

- update OpenAPI Schema with `asn` and `dataCenter` signals ([210b79a](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/210b79a86cd558c209342e10c24d17d4652a0bf9))
- update OpenAPI Schema with `auxiliaryMobile` method for VPN signal ([fcf0cf5](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/fcf0cf58eebbf17a99f1f601d00a323a379c4ab0))

## [2.3.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.2.1...v2.3.0) (2023-07-31)

### Features

- add `rawDeviceAttributes` signal as generic JObject ([40f5022](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/40f5022e2e960f2b99e98789275ddc0e8d80ff12))
- add smart signals support ([053779d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/053779d0d26544482c0461b00ecb7b4b5003c5cf))

## [2.2.1](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.2.0...v2.2.1) (2023-07-11)

### Bug Fixes

- ensure that SeenAt properties are correctly set in constructor ([9bd9e14](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/9bd9e14764dad8a8472f54619972867d871f5661))

## [2.2.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.1.0...v2.2.0) (2023-06-01)

### Features

- update schema with correct `IpLocation` format and doc updates ([4ddae4d](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/4ddae4dc2b279b8f15d1f5829b152b095bba31d3))

### Bug Fixes

- fix backtick problem in comments and documentation ([a12e9a3](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a12e9a3e2e14f357ca0ecdd96b53eae0d5cb3c3a))

## [2.1.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v2.0.0...v2.1.0) (2023-05-16)

### Features

- introduce new signals ([c38a0da](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/c38a0dacdebae155f97a942e6f16184f925f5413))

## [2.0.0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/compare/v1.0.0...v2.0.0) (2023-01-30)

### ⚠ BREAKING CHANGES

- changed `before` parameter type from `int` to `long`

### Features

- change `before` parameter type in /visits endpoint ([c9234aa](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/c9234aa30971f69d0965da66b70de211b6602d0d))

## 1.0.0 (2023-01-23)

### Features

- add identification error to events response ([a0afe34](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a0afe34a3e4d2dea7d3e56573d71ba72748cae8b))
- bump RestSharp to 108.0.3 ([a36615f](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/a36615f17a6fdefde279aef93e8e1d89b27cad75))
- change namespace from Fingerprint.Sdk to Fingerprint.ServerSdk ([250b756](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/250b756ec21162bf90dc2f5ca010f012804544e8))
- introduce TooManyRequestsException ([bd94cf8](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/bd94cf8f31c50019b5dcba68b4b3a1c9d1389aeb))
- rename package to match new root namespace ([e457a69](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/e457a6932d871e9371ea72c9faa2e411604e3439))
- require passing api key in Configuration constructor, remove default configuration ([b7b6e0f](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/b7b6e0fbbc39c88ec3740a2a05f94339385988e3))
- send "ii" parameter ([c09dab0](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/c09dab0bfd30eb94fa5d206b7236e24b55a2ea28))
- support other API regions ([ccc9250](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/ccc9250d901dd24e58a81873afaa0000eea6b858))
- support other dotenv frameworks as well ([692f1bc](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/692f1bc7c4be0e164a39b53777f164cf3b0ff45a))
- update client to latest schema version ([29e1d24](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/29e1d242332032fd34ef34901287388c85c815c0))

### Documentation

- **README:** add badges ([c3a7f87](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/c3a7f87ea6d390d8fb18dc09a77b0c94556e805d))
- **README:** add install command and fix style problems ([4798730](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/47987309a0dcb8d63a42bb6863fb0328e7f3b705))
- **README:** add logo ([55f72fb](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/55f72fbfee8e4e206a93f1419c370c0fdaefbb03))
- **README:** add separate readme to package ([6572a05](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/6572a05a311954342a7e46cc30fc4d2442c5d252))
- **README:** include readme and license ([6102d58](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/6102d589823e0bcefd25e08a6cd0d16304e6321a))
- **README:** update readme and license ([074fa61](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/074fa61464b423fd52e2503e977dca3e21122670))

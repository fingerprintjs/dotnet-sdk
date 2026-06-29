---
'fingerprint-server-dotnet-sdk': patch
---

Support deserializing enum values that are not yet known to the SDK. When the API returns an enum value this SDK version does not recognize (including on required fields such as `proxy_details.proxy_type`), it now deserializes to the catch-all `UnsupportedValueSdkUpgradeRequired` member instead of throwing.

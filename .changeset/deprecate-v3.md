---
"fingerprint-pro-server-api-dotnet-sdk": minor
---

### SDK Changes ([bdcf7de](https://github.com/fingerprintjs/fingerprint-pro-server-api-dotnet-sdk/commit/bdcf7def8039025d95e418936f3b47e824966844))

- Add `WorkspaceScopedSecretKeyRequired` error code
- Add optional `Type` field to `IPInfoASN` response model
- Add `Integrations` field to `SDK` model with a list of `Integration` and `IntegrationSubIntegration`.

### Deprecation

:warning: `FingerprintPro.ServerSdk` uses Server API v3, which is deprecated. Please migrate to the new
[`Fingerprint.ServerSdk`](https://github.com/fingerprintjs/dotnet-sdk) package which uses Server API v4.
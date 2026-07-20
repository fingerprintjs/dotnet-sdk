# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

Before reading or editing files in this repo, read [contributing.md](./contributing.md) for details specific to this repo.

## Architecture of the generated client

- `Api/` - `FingerprintApi` + `IFingerprintApi`, one method per endpoint. Responses are wrapped in an `ApiResponse<T>` exposing `IsOk`/`Ok()`, `TryOk(out …)`, and per-status accessors (`IsNotFound`/`NotFound()`, `TooManyRequests()`, etc.) rather than throwing on non-2xx.
- `Client/` - infrastructure: `HostConfiguration` (DI setup, region), `Region`, token providers (`BearerToken`, `RateLimitProvider`, `TokenProvider`), JSON converters, `ApiFactory`.
- `Extensions/` - `IHostBuilderExtensions` (`ConfigureFingerprint`), `IServiceCollectionExtensions`, `IHttpClientBuilderExtensions` (retry/timeout/circuit-breaker policies). Consumers configure everything through `ConfigureFingerprint` on the host builder.
- `Model/` - generated DTOs, one file per schema.
- `Sealed.cs` / `WebhookValidation.cs` - hand-authored features (from custom templates), the SDK's value-add beyond raw endpoint bindings.

## Changesets

When asked to add changeset, do so in the `.changeset` directory using the following template:

``` markdown 
---
'fingerprint-server-dotnet-sdk': patch | minor | major
---

User-facing changes description.
```

Name the file as `<change_name>.md`.
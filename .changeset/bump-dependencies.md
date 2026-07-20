---
'fingerprint-server-dotnet-sdk': minor
---

Update dependencies: bump `Microsoft.Extensions.Http`/`Microsoft.Extensions.Hosting` to 8.0.1 and `Microsoft.Extensions.Http.Polly` to 8.0.8. This raises the minimum transitive dependency floor (including `System.Text.Json` 8.0.5) for `netstandard2.0` and `net48` consumers.
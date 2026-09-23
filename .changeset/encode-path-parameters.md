---
'fingerprint-pro-server-api-dotnet-sdk': patch
---

URL-encode path parameters. `GetEvent`, `UpdateEvent`, `GetVisits`, and `DeleteVisitorData` now throw an `ArgumentException` without sending a request when the request or visitor ID is empty, `.`, or `..`.

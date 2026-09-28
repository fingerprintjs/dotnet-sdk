---
'fingerprint-pro-server-api-dotnet-sdk': patch
---

Fix `GetEvent`, `UpdateEvent`, `GetVisits`, and `DeleteVisitorData` returning data for a different request when the `requestId` or `visitorId` argument contains special characters. These methods now throw an `ArgumentException` when the argument is empty, `.`, or `..`.

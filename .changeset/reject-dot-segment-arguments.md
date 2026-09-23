---
'fingerprint-server-dotnet-sdk': patch
---

Reject `.` and `..` as event and visitor IDs. `GetEventAsync`, `UpdateEventAsync`, and `DeleteVisitorDataAsync` now throw an `ArgumentException` when the `eventId` or `visitorId` argument is empty, `.`, or `..`, instead of returning data for a different request.

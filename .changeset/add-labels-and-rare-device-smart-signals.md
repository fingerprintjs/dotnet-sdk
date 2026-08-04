---
'fingerprint-server-dotnet-sdk': minor
---

Update Server API schema to v3.5.2:

- **events**: Add `labels` field with machine learning based predictions for specific use cases (beta).
- **events**: Add `rareDevice` Smart Signal with `result` and `percentileBucket`.
- **events-search**: Add `rare_device` and `rare_device_percentile_bucket` filters.
- **events**: Add `mlScore` fields to the `VPN` and `Proxy` signals, and `mlPrediction` to `VPNMethods` (beta).
- Clarify the `DeveloperTools` signal description to cover Android/iOS devices.

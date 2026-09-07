---
'fingerprint-pro-server-api-dotnet-sdk': minor
---

Update Server API schema to v3.7.1:

- **events**: Add `RequestReadTimeout` error code
- **events-search**: Document `429` and `504` error responses for `GET /events/search`
- **events-search**: Clarify the `reverse` parameter description and set its default value to `false`
- **events**: Mark `Labels.label` field **required**
- **visitors**: Document `404`, `429`, and `504` error responses for `GET /visitors/{visitor_id}`
- **visitors**: Clarify that `GET /visitors/{visitor_id}` returns at most one item in `visits`, and update `limit`/`paginationKey`/`before` descriptions accordingly
- Clarify the `ProxyDetails.proxyType` description

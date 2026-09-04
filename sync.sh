#!/bin/bash
set -euo pipefail

defaultBaseUrl="https://fingerprintjs.github.io/fingerprint-pro-server-api-openapi"
# Flattened Event (single object, source optional). start/end split into start + start_date_time.
schemaUrl="${1:-$defaultBaseUrl/schemas/fingerprint-server-api-v4-normalized.yaml}"
examplesBaseUrl="${2:-$defaultBaseUrl/examples}"

mkdir -p ./res

curl -fSL -o ./res/fingerprint-server-api.yaml "$schemaUrl"

examplesList=(
  'errors/400_ip_address_invalid.json'
  'errors/400_request_body_invalid.json'
  'errors/403_feature_not_enabled.json'
  'errors/404_visitor_not_found.json'
  'errors/404_event_not_found.json'
  'errors/409_state_not_ready.json'
  'errors/429_too_many_requests.json'
  'events/get_event_200.json'
  'events/search/get_event_search_200.json'
  'webhook/webhook_event.json'
)

baseDestination="./src/Fingerprint.ServerSdk.Test/mocks"

for example in "${examplesList[@]}"; do
  destinationPath="$baseDestination/$example"
  destinationDir="$(dirname "$destinationPath")"

  mkdir -p "$destinationDir"

  echo "Downloading $example to $destinationPath"
  curl -fSL -o "$destinationPath" "$examplesBaseUrl/$example"
done

echo "All OpenAPI documentation downloads complete."
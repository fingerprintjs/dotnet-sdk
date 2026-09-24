#!/usr/bin/env bash
set -euo pipefail

# Resolve paths relative to the repository root, so the script can be run from
# any working directory.
cd "$(dirname "${BASH_SOURCE[0]}")"

defaultBaseUrl="https://fingerprintjs.github.io/openapi"
schemaUrl="${1:-$defaultBaseUrl/schemas/fingerprint-server-api-v4.yaml}"
examplesBaseUrl="${2:-$defaultBaseUrl/examples}"

CURL_OPTS=(-fSL --retry 3 --proto-redir '=https' --connect-timeout 10 --max-time 300)
if [[ "${TRACE:-}" != "true" && "${ACTIONS_STEP_DEBUG:-}" != "true" ]]; then
  CURL_OPTS+=(-s)
fi

schemaDestination="./res/fingerprint-server-api.yaml"
exampleBaseDestination="./src/Fingerprint.ServerSdk.Test/mocks"

mkdir -p "$(dirname "$schemaDestination")"

echo "Downloading $schemaUrl to $schemaDestination"
curl "${CURL_OPTS[@]}" -o "$schemaDestination" "$schemaUrl"

examples=(
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

for example in "${examples[@]}"; do
  destinationPath="$exampleBaseDestination/$example"
  mkdir -p "$(dirname "$destinationPath")"

  exampleUrl="$examplesBaseUrl/$example"
  echo "Downloading $exampleUrl to $destinationPath"
  curl "${CURL_OPTS[@]}" -o "$destinationPath" "$exampleUrl"
done

echo "All OpenAPI schema downloads complete."

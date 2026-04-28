#!/bin/bash
set -euo pipefail

# Cleanup
rm -Rf ./docs
rm -Rf ./src/Fingerprint.ServerSdk

OPENAPI_GENERATOR_IMAGE_VERSION="v7.19.0"

docker run --rm -u "$(id -u):$(id -g)" -v "${PWD}:/local" -w /local "openapitools/openapi-generator-cli:${OPENAPI_GENERATOR_IMAGE_VERSION}" generate \
  -i ./res/fingerprint-server-api.yaml \
  -g csharp \
  -o ./ \
  -t ./template \
  -c ./config.json

# Fix api doc
mv ./docs/apis/FingerprintApi.md ./docs/FingerprintApi.md
rm -rf ./docs/apis

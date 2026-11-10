#!/bin/bash
set -euo pipefail

# Cleanup
rm -Rf ./docs
rm -Rf ./src/Fingerprint.ServerSdk

OPENAPI_GENERATOR_IMAGE_VERSION="v7.23.0@sha256:5ffccd3b0d4ac57eac443e1c9b3e2f2bb7f0a21ffe6c6701f3690d7edc78bf2d"

docker run --rm -u "$(id -u):$(id -g)" -v "${PWD}:/local" -w /local "openapitools/openapi-generator-cli:${OPENAPI_GENERATOR_IMAGE_VERSION}" generate \
  -i ./res/fingerprint-server-api.yaml \
  -g csharp \
  -o ./ \
  -t ./template \
  -c ./config.json

# Fix api doc
mv ./docs/apis/FingerprintApi.md ./docs/FingerprintApi.md
rm -rf ./docs/apis

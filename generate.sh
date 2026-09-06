#!/bin/bash
set -euo pipefail

# Cleanup
rm -Rf ./docs
rm -Rf ./src/Fingerprint.ServerSdk

OPENAPI_GENERATOR_IMAGE_VERSION="v7.23.0"

docker run --rm -u "$(id -u):$(id -g)" -v "${PWD}:/local" -w /local "openapitools/openapi-generator-cli:${OPENAPI_GENERATOR_IMAGE_VERSION}" generate \
  -i ./res/fingerprint-server-api.yaml \
  -g csharp \
  -o ./ \
  -t ./template \
  -c ./config.json

# Fix api doc
mv ./docs/apis/FingerprintApi.md ./docs/FingerprintApi.md
rm -rf ./docs/apis

# Event source hydrate lives outside generated converters so generate can
# wipe src/Fingerprint.ServerSdk without losing omit→device.
cp ./custom/EventSourceHydration.cs ./src/Fingerprint.ServerSdk/Model/EventSourceHydration.cs
cp ./custom/EventHydratingJsonConverter.cs ./src/Fingerprint.ServerSdk/Model/EventHydratingJsonConverter.cs
perl -pi -e 's/new EventJsonConverter\(\)/new EventHydratingJsonConverter()/g' ./src/Fingerprint.ServerSdk/Client/HostConfiguration.cs ./src/Fingerprint.ServerSdk/Sealed.cs

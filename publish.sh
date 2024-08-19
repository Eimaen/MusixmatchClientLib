#!/bin/bash

set -e

echo "Publishing..."

cd ./MusixmatchClientLib
dotnet pack -c Release MusixmatchClientLib.csproj -p:PackageVersion="$RELEASE_VERSION"
nuget push "./bin/Release/MusixmatchClientLib.$RELEASE_VERSION.nupkg"\
  -ApiKey "$NUGET_TOKEN"\
  -NonInteractive\
  -Source https://www.nuget.org/api/v2/package

cd ..
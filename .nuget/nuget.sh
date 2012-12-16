#!/bin/sh

cd packages
mono ../.nuget/NuGet.exe install ../Chapter7/packages.config
mono ../.nuget/NuGet.exe install ../Chapter8/packages.config 

echo "Done" 
#!/usr/bin/env bash

#Install 

set -e

# Installing code cov.
echo "installing code coverage"
curl -s https://codecov.io/bash > codecov
chmod +x codecov


# Installing dotnet tools
echo "installing dotnet tools"
dotnet tool install -g Cake.Tool || echo "skip"
dotnet tool install -g GitVersion.Tool || echo "skip"
dotnet tool install -g dotnet-sonarscanner || echo "skip"
PATH=$PATH:~/.dotnet/tools

# making the solution

echo "building the solution"
make build

echo "running the coverage"
make coverage

echo "deploying documentation"
make docs

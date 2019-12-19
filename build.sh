#!/usr/bin/env bash

#Install 

set -e

# Installing code cov.
echo "installing code coverage"
curl -s https://codecov.io/bash > codecov
chmod +x codecov

# Restoring dot net tools
dotnet tool restore

# Restoring dot net paket
dotnet paket install

# making the solution

echo "building the solution"
make build

echo "running the coverage"
make coverage

echo "deploying documentation"
make docs

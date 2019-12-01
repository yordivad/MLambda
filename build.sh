#!/usr/bin/env bash

#Install 

set -e

make build

make coverage

make docs

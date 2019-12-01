#!/usr/bin/env bash

#Install 

make build || (echo "the build  failed $$?"; exit 1)

make docs || (echo "the documentation failed $$?"; exit 1)

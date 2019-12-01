#Makefile

.PHONY: help

build:
	dotnet cake build.cake
	./codecov  -t $(CODECOV_TOKEN)
	
docs:
	@echo 'making the docs.'
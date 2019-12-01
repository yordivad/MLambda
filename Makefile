#Makefile

.PHONY: all

all: 
	@echo ""

build:

ifeq ($(TRAVIS_PULL_REQUEST), false)
	dotnet cake build.cake
else
	dotnet cake build.cake --target=check
endif

coverage:	
	./codecov  -t $(MLAMBDA_TOKEN)

docs:
	@echo 'making the docs.'
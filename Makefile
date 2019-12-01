#Makefile

.PHONY: help

build:
	dotnet cake build.cake

coverage:	
	./codecov  -t $(CODECOV_TOKEN)
		
docs:
	@echo 'making the docs.'
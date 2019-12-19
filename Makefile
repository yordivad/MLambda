#Makefile

VERSION="$(shell dotnet gitversion /showvariable NuGetVersion)"


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

deploy:

ifeq ($(TRAVIS_PULL_REQUEST), false)	
	@dotnet cake ./build.cake --target=deploy
	@docker login -u roygi -p $(APIKEY) roygi-docker-mdocker.bintray.io

#Copy the kube config
	[ -d $(HOME)/.kube ] || mkdir -p $(HOME)/.kube
	@cp ./k8s/template/config.yml $(HOME)/.kube/config
#Setting the kube config.
	@sed -i "s|{{cluster}}|$(CLUSTER)|g" ${HOME}/.kube/config
	@sed -i "s|{{server}}|$(SERVER)|g" ${HOME}/.kube/config
	@sed -i "s|{{user}}|$(USER)|g" ${HOME}/.kube/config
	@sed -i "s|{{token}}|$(TOKEN)|g" ${HOME}/.kube/config
	@sed -i "s|{{certificate}}|$(CERTIFICATE)|g" ${HOME}/.kube/config
	@kubectl config use-context $(CLUSTER)
# Executing skaffold
	[ -d .skaffold ] || mkdir .skaffold
	@skaffold build -f skaffold.yaml --file-output .skaffold/build-$(VERSION).json
	@skaffold deploy -f skaffold.yaml -a .skaffold/build-$(VERSION).json --status-check

endif


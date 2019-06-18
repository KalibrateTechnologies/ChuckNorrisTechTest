.PHONY: clean build publish package

APPLICATION?=ChuckNorris.API
SOLUTION=$(APPLICATION).sln
PACKAGE = ChuckNorris.API
APP_VERSION?=1.0.0.0
CONFIGURATION?=Release
PUBLISH_DIR=${CURDIR}/out

clean:
	dotnet clean -c $(CONFIGURATION)

build:
	dotnet build -c=$(CONFIGURATION) $(SOLUTION)

publish:
	dotnet publish -o $(PUBLISH_DIR) -c $(CONFIGURATION) --no-build $(SOLUTION) 
	
# ChuckNorrisTechTest
Chuck Norris Tech Test for candidates

# IIS Setup
Set up an IIS website called `ChuckNorris` pointing to the UI Build Folder

Update the Hosts file in `C:\Windows\System32\drivers\etc`

Add an Application under the website called `ChuckNorrisApi` pointing to the API out folder

# Build
To build the API run `make build` in the API route
To publish the API runt `make publish` in the API route (after make build)

To build the UI run `npm run build`in the chuck-norris-ui folder

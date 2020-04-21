# ChuckNorrisTechTest
Chuck Norris Tech Test for candidates

The Chuck Norris App has two parts:
1. A React front end that calls the back end for a Joke
2. A C# back end API that calls https://rapidapi.com/matchilling/api/chuck-norris for a Joke

# IIS Setup
Set up an IIS website called `ChuckNorris` pointing to the UI Build Folder

Update the Hosts file in `C:\Windows\System32\drivers\etc`

Add an Application under the website called `ChuckNorrisApi` pointing to the API out folder

# Build
To build the API run `make build` in the API route
To publish the API runt `make publish` in the API route (after make build)

To build the UI run `npm run build`in the chuck-norris-ui folder

# Challenges
Candidates should be tested using the CandidateBranch

The Chuck Norris App has a facility to retrieve a Joke and display it, there is a button to refresh the Joke and retrieve a new one.

There is already harness code in the front and back ends, we need you to fill the gaps for implementing Search functionality. You need to add a Search button and a text box to the front end that retrieves a list of Jokes from the back end. You may style the list of Jokes in any style you wish

# Levels_Beyond_Code_Assessment

-Backend:
RESTful, JSON API hosted at notemanager2017.azurewebsites.net/api/notes

Supported Verbs:
.GET: 
	curl -i -H "Content-Type: application/json" -X GET http://noteManager2017.azurewebsites.net/api/notes
	curl -i -H "Content-Type: application/json" -X GET http://noteManager2017.azurewebsites.net/api/notes/1
	curl -i -H "Content-Type: application/json" -X GET http://noteManager2017.azurewebsites.net/api/notes?query=milk

.POST:
	curl -i -H "Content-Type: application/json" -X POST -d '{"Body" : "Pick up milk!"}' http://noteManager2017.azurewebsites.net/api/notes

.DELETE:
	curl -i -H "Content-Type: application/json" -X DELETE http://notemanager2017.azurewebsites.net/api/notes/1

Setup:
I decided to host my notes api on azure to make configuration as straightforward as possible. Simply run the above commands to interract with the api. I've also placed my entire solution in /Backend. If you have Visual Studio installed, you can run the software by opening the solution in VS and pressing F5. You may then interact with the api on localhost.

-Front End:
I used AngularJS to complete this portion of the assessment

Setup:
I've placed my entire application in /Front End. Although there are many ways to run the application, here is an example:
	1) Install Node.js at the following link: https://nodejs.org/en/download/
	2) Run npm install -g http-server on the command line to install node.js http-server
	3) Navigate to /Front End and run http-server -o on the command line to open a browser and observe the application running
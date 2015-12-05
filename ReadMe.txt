Service Solution
*Always run as administrator unless you install the solution under MyDocuments
*I recommend downloading Notepad++ with the http://www.sunjw.us/jstoolnpp/ plugin for JSON formatting
*I recommend that you install Powershell ISE if you don't find it on your system. Depending on your Windows version it may be a download or a feature.
*You may need to install the following download for the Entity Framework http://www.microsoft.com/en-us/download/confirmation.aspx?id=40762

1) Creating Database
	-The database project contains a CreateObjects.cmd that will provision the database using the SQL scripts inside the database project.
	-The default settings install into (local)\SQLExpress and the database named Authorization
	-You need to create the database first
	-SQLExpress is free and should come with Visual Studio
	-SQLManagementStudio is also a free download and will allow you to browse the database server
	-The main administrator is located in the script Authorization\Database\Data\Admins.sql - You will need this to create a login session in order to call the APIs

2) Running the UnitTests
	-The unit tests use NUnit (also a free download)
	-Once the database is setup and the project is built, you can run the UnitTests by running Nunit and opening Services.nunit included with the solution
	-Click the run button - light is green, trap is clean :-)
	-Use the debugger and attach to nunit-agent.exe to debug through the unit tests and watch what is going on in the Entity Framework
	-I am not an expert on Entity Framework - I was just playing
	-Entity Framework allows you to use C# and LINQ rather than SQL - Not a good or bad thing, just a thing

3) Running the web application
	-You can run the web application and it should use the IISExpress to open the project in a browser
	-There is an API link that will describe the restful API
	-I added config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); to the WebApiConfig.cs to force camel case property names - That is the rest standard

4) Using the rest API
	-Once the application is running, you can see the API help page
	-There is a http://localhost:4394/Help page (please note your port may be different)
	-Sample usage from Powershell located in the POSH folder
	-CreateSession.ps1 will create a login session. The sessionId (looks like a GUID needs to be passed to the rest of the APIs)
	-ListRoles.ps1 will create a login session as the administrator and do a GET on the Role API


5) Logging
	-I added log4net.
	-The config file is log4net.config
	-Configuring the log4net framework is done at application startup in Global.asax
	-Log file: C:/Temp/Logs/Service/Application.txt
	-You'll see a _log static member in the controllers - Use this member to write info, debug, warn, or error to the logs


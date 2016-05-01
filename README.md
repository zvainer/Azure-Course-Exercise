# Azure Course Exercise
This repositoty acts as the basis for a rolling exercise in CodeValue's Microsoft Azure course.
## Prerequisites
1. The code is built and tested using Visual-Studio 2015 Update 2 and .NET 4.6.1.
2. The system is preconfigured to use SQL Server LocalDB for the database stores. SQL Server Express (or any other edition) can be used, however the application settiongs should be changed accordingly in the system configuration files.

## Compiling and Running the System
In order to compile the code:

1. Clone or download the repository.
2. Open the "CodeTweet\CodeTweet.sln" file in Visual-Studio.
3. Compile. Visual Studio should restore all the required NuGet packages automatically.

## Running the System
There are two processes required in order to run the system in full:

1. "CodeTweet.Web" which as the ASP.NET MVC front-end for the system.
2. "CodeTweet.Worker" which hosts the backend notification service.

Note that the system can also run correctly without the notification service, by not running the backend process.

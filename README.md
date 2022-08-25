# TODO

- Developement / Production Environment
- Best practice REST API exception handling/logging
  - general (e.g. http response)
  - global exception handling (e.g. old HotelListing example)
    - ExceptionFilterAttribute
  - environment related (dev, production)
- UnitOfWork / Repository Pattern ?
- Seq online
- Mongo Atlass instead of local db
- Deploy Api

# Setup

- Create Project and Solution `ASP.NET Core Web API`
- **CORS** configuration
- **Serilog** and **Seq**
  - **ps script** for checking and starting mongodb and seq service
- MongoDB driver and configuration
- Services & Controllers
  - Create Services and **register** in `Programm.cs` to DI Container
  - **Inject** service in Controller
  - **Logging** and **ExceptionHandling** in Service/Controller

## Serilog

- <https://www.youtube.com/watch?v=MYKTwvowMUI>
- <https://www.youtube.com/watch?v=hJ0QHRV3RPQ>
  - <https://github.com/rstropek/htl-leo-pro-5/tree/master/lectures/0500-api-error-handling/WebApiErrorHandling.Server>
- <https://www.youtube.com/watch?v=_iryZxv8Rxw>

## Seq

- **Install** seq and use **Sink** in `appsettings.json`
- Using RequestID in search to find all request related stuff: `RequestId = "0HMHQ499O1RPJ:0000001B"`

## Error / Exception handling

- <https://jasonwatmore.com/post/2022/01/17/net-6-global-error-handler-tutorial-with-example>
- <https://weblogs.asp.net/fredriknormen/asp-net-web-api-exception-handling>
- <https://stackoverflow.com/questions/10732644/best-practice-to-return-errors-in-asp-net-web-api>
- <https://docs.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling>
- <https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-6.0>
- <https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-6.0>

## MongoDB

- NO Entityframework Core (best for relational databases!)
- MongoDb.Driver nuget
- <https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio>

- Add configuration and configuration model
  - `appsettings.json`
  - settings class in `Models` directory, to store appsettings properties
  - `Program.cs`

### CLI commands

- <https://www.mongodb.com/docs/manual/reference/mongo-shell/>
- <https://tecadmin.net/tutorial/mongodb/mongo-shell/>

```bash
mongosh
show dbs
use <dbname>
show collections
db.getCollectionInfos();
db.hotels.find()
db.hotels.find({"Name":"HotelOne"})
```

## Swagger

## Environments

- <https://www.youtube.com/watch?v=_2_qksdQKCE>
- <https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-6.0>

# Run App

Check if Seq and Mongo services are running
```shell
.\CheckAndStartService.ps1
```

Start app
```shell
dotnet run
```

Endpoints:
- Serilog: <http://localhost:5341/#/events>
- App: <https://localhost:7269/swagger/index.html>

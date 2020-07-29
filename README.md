# City Info App

ASP.NET is a cross-platform framework for building modern cloud based internet connected applications:
- Web Apps
- APIs
- mobile APPs
- apps for IoT

It is:
- open source
- cross-platform

Tooling:
- Visual Studio 2019 Community Edition
- .NET Core


# Middleware for building an API:

In oler ASP.NET applications we had:
- ASP.NET Web API (http services)
- ASP.NET MVC (cliet-facing web applications)

The previous sections have been unified in:
- ASP.NET Core MVC

Notes:
-ASP.NET by default serializes and deserialize to and from JSON

# Data Validation


Data validation can be acheaved with data annotations and model state:

### 1. Data annotations inside the model:

```C#
public class PointOfInterestForCreationDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }
}
```

### 2. ModelState inside the controller

ModelState is a doctionary:
- containing both the state of the model and the model binding validation
- it represents a collection of name and value pairs that were submitted to our API (one for each property)
- contains also a collection of error messages for each value submitted
- => so the rules applied to the DTO are checked

```C#
if (!ModelState.IsValid)
{
    return BadRequest();
}
```

- the check above is done automatically by the API


### NOTES

More complex validation rules can not be written in the DTO and should be manually performed.
Headers can be added to our ModelState ro they are returned when we return a BadRequest

```C#
if (pointOfInterest.Name == pointOfInterest.Description)
{
    ModelState.AddModelError(
        "Description",
        "The provided description should be different from the name."
    );
}

if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}
```

**Having validation both in the controller and the model does not adhere to the separation of concerns rule.** 
For more complex validations one can have a look at https://github.com/FluentValidation/FluentValidation

# Updating resources

There are two ways of updating resources:
- full update (PUT)
- partial update (PATCH)

# Logging

The default logger can be injected inside the controller:

```C#
public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
{
    _logger = logger ?? throw new ArgumentNullException("logger");
}
```

This logger logs only to the console but it can be overriden with a custom logger provider like **NLog**:
https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-2 (or -3)

The corresponding nuget package is: **NLog.Web.AspNetCore**

## Configure NLog

- in the root folder of the project add `nlog.config`

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

	<!-- enable asp.net core layout render -->
	<extensions>
		<add assembly="NLog.Web.AspNetCore"/>
	</extensions>

	<targets>
		<target name="logfile" xsi:type="File" fileName="nlog-{shortdate}.log" />
	</targets>

	<rules>
		<logger name="*" minlevel="Info" writeTo="logfile" />
	</rules>
</nlog>
```

NOTE: it is important that `nlog.config` is copied to the output directory.

- tell the logger factory to use this provider:

```C#
public class Program
{
    public static void Main(string[] args)
    {
        // logger can not be injected here because the building container hasn't been setup yet
        // so we get manually get the logger:
        var logger = NLogBuilder
            .ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();

        try
        {
            logger.Info("Initializing application...");
            CreateWebHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Application stopped because of exception.");
        }
        finally
        {
            NLog.LogManager.Shutdown();
        }
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
}
```

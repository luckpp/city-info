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
- full update
- partial update
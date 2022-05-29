# SnowStorm.Sample
Sample code on how to use SnowStorm NuGet package.

* THIS IS A WORK IN PROGRESS!! *

## Patterns
 - CQRS
 - MediatR (mediator)
 - REST Web Api

## Swagger

- https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-6.0&tabs=visual-studio


## REST Web Api

Important principles to keep in mind.
 - The route (path) represent objects (plural)
 - HTTP Actions are the action to be applied on the object(s)

 Examples:
|Route|Action|Description|
|api/seminars| GET |Listing all seminars|
|api/seminars/{id}| GET |Listing a specified seminar based on id|
|api/seminars| POST |Create a new Seminar|
|api/seminars/{id}| POST |Can be used to update a specified seminar, or create a new one if the id is null|
|api/seminars/{id}| DELETE |Delete a specified seminar based on id|
|api/seminars/{id}/attendees| GET |Listing all attendees of a specified seminar based on id|
|api/seminars/{id}/attendees/{attendeeId}| GET |Listing a specified attendee of a specified seminar based on id|
|api/seminars/{id}/attendees| POST |Create a new attendee of a specified seminar based on id|
|api/seminars/{id}/attendees/{attendeeId}| DELETE |Delete a specified attendee of a specified seminar based on id|
|api/seminars/attendees/{attendeeId}| GET |Listing a specified attendee based on id|

## Standards like OPEN API
 - Standards like Open API is aimed at how the data is being retrieved and submitted.  A consisitent way the objects are formatted.
  
## Caching
 - Consider using built in memory cacheing.
   - services.AddMemoryCache();
 - Easier to implement
 - Lower costs

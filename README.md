# Product CRUD api using .Net 7 Minimal API and CQRS

example of using 2023's Mediatr v12  which had many breaking changes from v11

## Clean Architecture
### 4 Layers
* **Application layer**
  * Cqrs commands, queries and handlers
  * repository interface
  * references
    * Application -> Domain
* **DataAccess layer**
  * repositories, migrations
  * references
    * DataAccess -> Application
    * DataAccess -> Domain
* **Domain layer**
  * core business models
* **WebApi layer**
  * minimal api
  * references
    * WebApi -> DataAccess
### Patterns
* Repository pattern
* CQRS(Command Query Responsibility Segregation)
* Mediator pattern using MediatR

## Tech Stack:
* C#
* Asp.Net Core 7 new features
  * Minimal API
  * MapGroups
  * TypedResults
* Entity Framework
* SQL Server
* Mediatr v12

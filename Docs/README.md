# Arc for ASP.NET MVC (Clean Architecture Template)

A simple ASP.NET MVC clean architecture

## Technologies
 - .NET Framework
 - Entity Framework
 - [CQRS pattern with MediatR](https://www.nuget.org/packages/MediatR/)
 
## Overview

**Domain**  This layer contains all entities aggregates, enums, exceptions, event handlers and so on.

**Application**  This layer contains all application/business logic and model. It is dependent on the domain layer.

**Infrastructure**  This layer contains classes that accessing external resources particularly web services, server resources, SMTP and so on. Also, the persistence layer

**WebUI**  The entry point of the application is the ASP.NET web project.

## Discussions

Join our discord channel  [https://discord.gg/GdHCtHn](https://discord.gg/GdHCtHn)
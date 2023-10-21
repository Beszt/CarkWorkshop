# Car Workshop
Multiplatfom ASP.NET Simple code demo written in newer web technologies.

Live demo is available here [Car Workshop](http://carworkshop.obisoft.pl).

## Technology stack

### Backend
- NET 7.0 (C# 11)
- ASP.NET Core MVC
- ASP.NET Identity
- MediatR
- FluentValidation

## Database 
- Entity Framework
- AutoMapper
- PostgreSQL

### Frontend
- Razor Pages
- Bootstrap
- jQuery
- ToastR

### Tests
- Xunit
- FluentAssertion
- Moq

### Patterns
- Clean Architecture
- MVC
- CQRS

## Installation
1. Install [PostgreSQL Server](https://www.postgresql.org/download/) and make new database
2. Install [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
3. Download source code (all projects)
4. Navigate to presentation project folder (CarWorkshop.MVC)
5. Set connection string to your PostgreSQL database instance in `appsettings.json` file. In example:
```
"Host=localhost;Database=CarWorkshop;Username=postgresql;Password=PASSWORD;"
```
6. Type `dotnet run`

## More info
Special thanks to Jakub Kozera, this app is mostly based on his [ASP.NET Course](https://www.udemy.com/course/aspnet-core-mvc-kurs-od-podstaw-c-net).
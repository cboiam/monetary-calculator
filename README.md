# Monetary Calculator

This is a project built to be used in trainment of testing skills of my team, we'll build them in a context of the calculation of employee rights like vacation and rescission.

More about those calculus can be found in https://chcadvocacia.adv.br/blog/veja-como-calcular-rescisao-de-trabalho-dos-colaboradores/

Literatures to catch up with testing:

- [Martin Fowler](https://martinfowler.com/tags/testing.html)
- [Robert C. Martin](http://blog.cleancoder.com/)
- [Test pyramid applied to .Net](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/test-asp-net-core-mvc-apps)

## Running the application

To set up, start a postgre server, then on root folder run:

```
$ dotnet tool restore
$ dotnet database update -s src/MonetaryCalculator.Host -p src/MonetaryCalculator.Infra.Data
```

Run command inside the api project folder:

```
$ dotnet run
```

## Running the tests

Run command on the root folder or inside a test project folder:

```
$ dotnet test
```

## Built with

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) - _Software Developmet Kit (SDK)_
- [NUnit3](https://nunit.org/) - _Unit Test Framework_
- [Fluent Assertions](https://fluentassertions.com/) - _Fluent Unit Test Assertions Extension Methods_
- [Moq](https://github.com/moq/moq4) - _The most popular mocking library for .NET_
- [PostgreSQL](https://www.postgresql.org/) - _The World's Most Advanced Open Source Relational Database_

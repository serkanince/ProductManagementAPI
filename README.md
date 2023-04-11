# Product Management API

## Description

This example project is a solution for the e-commerce merchandising management system, which aims to create a business flow for CRUD transactions in the "Product" domain. The project is developed using .NET 7, Minimal API, Domain-driven Design (DDD), Command Query Responsibility Segregation (CQRS), and MediatR pattern.

It will be enough to run!

```
docker compose up -d --build
```
and browse api in Swagger
```
http://localhost:8000/swagger/index.html
```

## Technology Stack

- [x] `.Net 7`
- [x] `Minimal API` 
- [x] `Open API` with Swagger
- [x] `Dockerize` with Docker Compose
- [x] `PostgreSQL`
- [x] `CQRS` (with MediatR)
- [x] `Integration Test` with xUnit, TestServer
- [x] `Fluent Validation`
- [x] `SOLID` , `Clean Code`
- [x] `DDD`

---

### Project Structure:

* ProductManagement.API: This project contains the REST API endpoints for CRUD and filtering products.
* ProductManagement.Application: This project contains the application layer that handles the business logic of the project.
* ProductManagement.Domain: This project contains the domain models and interfaces.
* ProductManagement.Infrastructure: This project contains the implementation of the interfaces defined in the domain layer.

### How to run the project:

> You must install a .Net 6 before run [Download .Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

* Clone the repository to your local machine.
* Open the solution in Visual Studio or any other compatible IDE.
* Set the ProductManagement.API and Run with docker compose


### SS

Test Result

<img src="https://github.com/serkanince/ProductManagementAPI/blob/master/test-ss.jpg" alt="System Design" width="650"/>

Swagger

<img src="https://github.com/serkanince/ProductManagementAPI/blob/master/swagger-ss.jpg" alt="System Design" width="650"/>



# Employee Management System using REST API, GraphQL & gRPC

## Project Overview

This project demonstrates the implementation of **REST API**, **GraphQL**, and **gRPC** in a single .NET 8 application.

The application allows users to manage employee information, retrieve data using GraphQL, and communicate with a Notification Service using gRPC whenever a new employee is created.

---

# Technology Stack

* .NET 8 Web API
* ASP.NET Core
* Entity Framework Core 8
* SQL Server
* GraphQL (HotChocolate)
* gRPC
* Swagger/OpenAPI
* Visual Studio 2022

---

# Project Structure

```
EmployeeManagement.API
│
├── Controllers
├── Data
├── DTOs
├── Entities
├── GraphQL
├── Protos
├── Services
└── Program.cs

EmployeeManagement.Notification
│
├── Protos
├── Services
└── Program.cs
```

---

# Project Setup Instructions

## 1. Clone/Open the Project

Open the solution in **Visual Studio 2022**.

---

## 2. Configure Database

Update the connection string in **appsettings.json**.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 3. Apply Database Migration

Open **Package Manager Console** and execute:

```
Update-Database
```

This creates the required database tables.

---

## 4. Start the Notification Service

Set **EmployeeManagement.Notification** as a startup project or configure multiple startup projects.

The Notification Service starts on:

```
https://localhost:7155
```

---

## 5. Start the Employee API

Run **EmployeeManagement.API**.

Swagger will be available at:

```
https://localhost:<API_PORT>/swagger
```

GraphQL endpoint:

```
https://localhost:<API_PORT>/graphql
```

---

# REST API Endpoints

## Create Employee

**POST**

```
/api/Employee
```

Request Body

```json
{
  "name": "Akshaya",
  "email": "akshaya@gmail.com",
  "salary": 65000,
  "departmentId": 1
}
```

---

## Get All Employees

**GET**

```
/api/Employee
```

---

## Get Employee By Id

**GET**

```
/api/Employee/1
```

---

## Update Employee

**PUT**

```
/api/Employee/1
```

Request Body

```json
{
  "name": "Akshaya Deshmukh",
  "email": "akshaya@gmail.com",
  "salary": 70000,
  "departmentId": 1
}
```

---

## Delete Employee

**DELETE**

```
/api/Employee/1
```

---

# Sample GraphQL Queries

## Get All Employees

```graphql
query {
  employees {
    id
    name
    email
    salary
  }
}
```

---

## Get Employee By Id

```graphql
query {
  employee(id: 1) {
    id
    name
    email
    salary
  }
}
```

---

## Fetch Only Required Fields

```graphql
query {
  employee(id: 1) {
    name
    email
  }
}
```

This demonstrates GraphQL's flexibility by allowing clients to request only the fields they require.

---

# gRPC Workflow

The application uses gRPC for service-to-service communication.

### Workflow

1. Client sends a **POST** request to create a new employee.
2. The Employee API stores the employee in the SQL Server database.
3. After successful database insertion, the Employee API invokes the Notification Service using gRPC.
4. The Notification Service receives the employee details.
5. The Notification Service simulates sending a welcome notification by logging a success message to the console.

### Workflow Diagram

```
Client
   │
   ▼
REST API
(Create Employee)
   │
   ▼
SQL Server
(Employee Saved)
   │
   ▼
gRPC Client
   │
   ▼
Notification Service
   │
   ▼
Welcome Notification Sent
```

---

# Features

* Employee CRUD operations using REST API
* Flexible data retrieval using GraphQL
* Service-to-service communication using gRPC
* Entity Framework Core with SQL Server
* Swagger API documentation
* DTO-based API responses
* Clean and modular project structure

---

# Expected Output

### REST API

Employee records are created, updated, retrieved, and deleted successfully.

### GraphQL

Clients can retrieve only the required employee fields using GraphQL queries.

### gRPC

Whenever a new employee is created, the Notification Service logs a welcome notification, for example:

```
Welcome email sent to Akshaya (akshaya@gmail.com)
```

---

# Conclusion

This project demonstrates the practical implementation of three different communication protocols in ASP.NET Core:

* **REST API** for CRUD operations.
* **GraphQL** for flexible and efficient data retrieval.
* **gRPC** for high-performance service-to-service communication.

Each technology is used according to its strengths, providing a complete example of modern .NET application development.

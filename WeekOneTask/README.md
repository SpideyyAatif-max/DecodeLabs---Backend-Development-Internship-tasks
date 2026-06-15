Week 1 Internship Task
<p>Build a basic REST API.
Use ASP.NET Core Web API.
Create a local server.
Make the API stateless:
no sessions
no remembering old requests
every request works independently
Create GET routes:
GET /api/products
GET /api/products/{id}
Create POST route:
POST /api/products
Return data in JSON format.
Use proper HTTP status codes:
200 OK for successful GET
201 Created for successful POST
400 Bad Request for invalid input
404 Not Found if product not found
Use simple product fields:
id
name
description
price
inStock
Store data in a simple in-memory list for now.
Test all APIs using Postman or Swagger.
Organize code into folders:
Models
Controllers
DTOs
Services
Write a simple README.md:
project name
tech stack
how to run
API routes
sample request/response
Push the project to GitHub.
Final Deliverable

A working Product REST API with:
GET products
GET product by id
POST create product
JSON responses
correct status codes
GitHub repo


# Product REST API
A simple stateless REST API built with ASP.NET Core Web API for Week 1 Backend Development internship task.
## Project Goal
Build a local stateless web server that serves structured JSON data using GET and POST routes.
## Tech Stack
- C#
- ASP.NET Core Web API
- Swagger/OpenAPI
- In-memory list for temporary data storage
## Directory Structure
```text
ProductRestApi/
├── Controllers/
│   └── ProductsController.cs
├── Models/
│   └── Product.cs
├── DTOs/
│   ├── CreateProductDto.cs
│   └── ProductResponseDto.cs
├── Services/
│   ├── IProductService.cs
│   └── ProductService.cs
├── Common/
│   └── ApiResponse.cs
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
└── ProductRestApi.csproj
```
## How to Run
```bash
dotnet restore
dotnet run
```

Open Swagger:
```text
https://localhost:5001/swagger
```
or check the terminal output for the exact local URL.
## API Endpoints
### 1. Get All Products
```http
GET /api/products
```
### Success Response
```json
{
  "success": true,
  "message": "Products retrieved successfully",
  "data": [
    {
      "id": 1,
      "name": "Keyboard",
      "description": "Mechanical keyboard",
      "price": 50,
      "inStock": true
    }
  ]
}
```
## 2. Get Product By ID
```http
GET /api/products/1
```
### Success Response
```json
{
  "success": true,
  "message": "Product retrieved successfully",
  "data": {
    "id": 1,
    "name": "Keyboard",
    "description": "Mechanical keyboard",
    "price": 50,
    "inStock": true
  }
}
```
### Not Found Response
```json
{
  "success": false,
  "message": "Product not found",
  "data": null
}
```
## 3. Create Product
```http
POST /api/products
```
### Request Body
```json
{
  "name": "Monitor",
  "description": "24 inch LED monitor",
  "price": 150,
  "inStock": true
}
```
### Success Response
```json
{
  "success": true,
  "message": "Product created successfully",
  "data": {
    "id": 3,
    "name": "Monitor",
    "description": "24 inch LED monitor",
    "price": 150,
    "inStock": true
  }
}
```

## HTTP Status Codes Used

| Status Code | Meaning |
|---|---|
| 200 OK | GET request successful |
| 201 Created | Product created successfully |
| 400 Bad Request | Invalid input data |
| 404 Not Found | Product not found |

## Week 1 Concepts Covered

- Local backend server
- REST API fundamentals
- Stateless communication
- GET and POST routes
- JSON request and response
- DTOs
- Service layer
- Proper HTTP status codes
- Swagger API testing

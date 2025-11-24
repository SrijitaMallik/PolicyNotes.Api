## 📝 PolicyNotes API
A clean and simple ASP.NET Core Web API with Unit Testing & Integration Testing

This project implements a lightweight Policy Notes Management System built using ASP.NET Core Web API (.NET 8) and Entity Framework Core (InMemory).

It follows a clean architecture with separate layers for:

Controllers

Services

Repositories

Database (InMemory)

The assignment requirement of using two separate InMemory databases — one for development and one for integration testing — is fully implemented.

## 🚀 Features

⚙️ Clean Web API Architecture (Controller → Service → Repository)

🗃 EF Core InMemory Database

🔄 Full CRUD operations for Policy Notes

🧪 Unit Testing using xUnit + Moq

🔗 Integration Testing using WebApplicationFactory

🧬 Separate InMemory DB for Integration Tests

📂 Organized folder-based architecture

📄 Swagger UI auto-generated for all endpoints

🔐 Easily extendable to SQL Server / EF Core

## 📚 API Endpoints
Method	Route	Description
POST	/notes	Create a new policy note
GET	/notes	Fetch all notes
GET	/notes/{id}	Fetch a note by ID
🧪 Testing Overview
✔ Unit Tests

## 🏗 Project Structure
## 📁 Project Structure

The solution follows a clean architecture with API, Repository, Service, and Test layers.

## 📦 NuGet Packages
PolicyNotes.Api
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.InMemory
Swashbuckle.AspNetCore

PolicyNotes.Tests
Microsoft.AspNetCore.Mvc.Testing
Microsoft.EntityFrameworkCore.InMemory
Microsoft.NET.Test.Sdk
xunit
xunit.runner.visualstudio
Moq

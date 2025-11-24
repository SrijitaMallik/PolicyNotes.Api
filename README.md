##📝 PolicyNotes API
A clean and simple ASP.NET Core Web API with Unit Testing & Integration Testing

This project implements a lightweight Policy Notes Management System built using ASP.NET Core Web API (.NET 8) and Entity Framework Core (InMemory).

It follows a clean architecture with separate layers for:

Controllers

Services

Repositories

Database (InMemory)

The assignment requirement of using two separate InMemory databases — one for development and one for integration testing — is fully implemented.

##🚀 Features

⚙️ Clean Web API Architecture (Controller → Service → Repository)

🗃 EF Core InMemory Database

🔄 Full CRUD operations for Policy Notes

🧪 Unit Testing using xUnit + Moq

🔗 Integration Testing using WebApplicationFactory

🧬 Separate InMemory DB for Integration Tests

📂 Organized folder-based architecture

📄 Swagger UI auto-generated for all endpoints

🔐 Easily extendable to SQL Server / EF Core

##📚 API Endpoints
Method	Route	Description
POST	/notes	Create a new policy note
GET	/notes	Fetch all notes
GET	/notes/{id}	Fetch a note by ID
🧪 Testing Overview
✔ Unit Tests

Located in:

PolicyNotes.Tests/Unit/PolicyNoteServiceTests.cs


Covers:

Add Note

Get All Notes

Get Note By ID

Uses:

xUnit

Moq

✔ Integration Tests

Located in:

PolicyNotes.Tests/Integration/NotesApiIntegrationTests.cs


Integration tests:

Remove the DevDb registered in Program.cs

Inject a separate InMemory TestDb

Use TestServer via WebApplicationFactory

Test full API endpoints (POST, GET, etc.)

Fulfills assignment requirements 1, 2, and 3.

##🏗 Project Structure
PolicyNotes.Api/
│   Program.cs
│   appsettings.json
│
├── Controllers/
│      NotesController.cs
│
├── Data/
│      NotesDbContext.cs
│
├── DTOs/
│      NoteCreateDto.cs
│
├── Models/
│      PolicyNote.cs
│
├── Repositories/
│      IPolicyNoteRepository.cs
│      PolicyNoteRepository.cs
│
└── Services/
       IPolicyNoteService.cs
       PolicyNoteService.cs


PolicyNotes.Tests/
│
├── Unit/
│      PolicyNoteServiceTests.cs
│
└── Integration/
       NotesApiIntegrationTests.cs

##📦 NuGet Packages
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

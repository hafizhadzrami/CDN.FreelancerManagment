# CDN.FreelancerManagment

> By ETIQA IT – Revised June 2025  
> Complete Developer Network (CDN) – Freelancer Management System

![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![Build](https://img.shields.io/badge/build-passing-brightgreen)
![Tests](https://img.shields.io/badge/tests-100%25-success)

---

## 📌 Project Overview
This project is a **.NET 8/9 Web API** built using **Clean Architecture** principles.  
It manages a directory of freelancers, storing their details, skills, and hobbies.  
The API provides full CRUD, search, and archive/unarchive functionality.

---

## 🛠️ Tech Stack
- **ASP.NET Core Web API**
- **Entity Framework Core** (with code-first migrations)
- **SQL Server** (any RDBMS supported)
- **xUnit + Moq** for unit testing
- **Swagger/OpenAPI** for API documentation

---

## 📂 Solution Structure

CDN.FreelancerManagment/
├── CDN.Api/ → Presentation Layer (Controllers, Swagger)
├── CDN.Application/ → Application Layer (DTOs, Services, Interfaces)
├── CDN.Domain/ → Domain Layer (Entities, Models)
├── CDN.Infrastructure/ → Infrastructure Layer (EF Core, Repository Implementation)
├── CDN.Freelancers.Tests/→ Test Layer (xUnit, Moq)
└── README.md → Project documentation

---

## 🚀 Features Implemented
- ✅ CRUD Operations (`GET`, `POST`, `PUT`, `DELETE`)  
- ✅ **Archive / Unarchive** freelancer  
- ✅ Store **Skillsets & Hobbies** in separate one-to-many tables  
- ✅ **Wildcard Search** on username & email  
- ✅ **Clean Architecture** (Domain, Application, Infrastructure, Api)  
- ✅ **Unit Tests** (xUnit + Moq)  
- ✅ Swagger UI at: `https://localhost:7007/swagger/index.html`

---

## ⚙️ Prerequisites
- [.NET 8/9 SDK](https://dotnet.microsoft.com/download)  
- SQL Server (localdb/express/any RDBMS)  
- Visual Studio / VS Code  

---

## 🏗️ Setup & Run
1. Clone repository:
   ```sh
   git clone <your-repo-url>
   cd CDN.FreelancerManagment


---

## 🚀 Features Implemented
- ✅ CRUD Operations (`GET`, `POST`, `PUT`, `DELETE`)  
- ✅ **Archive / Unarchive** freelancer  
- ✅ Store **Skillsets & Hobbies** in separate one-to-many tables  
- ✅ **Wildcard Search** on username & email  
- ✅ **Clean Architecture** (Domain, Application, Infrastructure, Api)  
- ✅ **Unit Tests** (xUnit + Moq)  
- ✅ Swagger UI at: `https://localhost:7007/swagger/index.html`

---

## ⚙️ Prerequisites
- [.NET 8/9 SDK](https://dotnet.microsoft.com/download)  
- SQL Server (localdb/express/any RDBMS)  
- Visual Studio / VS Code  

---

## 🏗️ Setup & Run
1. Clone repository:
   ```sh
   git clone <your-repo-url>
   cd CDN.FreelancerManagment

2. Update appsettings.json with your DB connection string.

3. Run migrations:
	dotnet ef database update --project CDN.Infrastructure --startup-project CDN.Api

4. Run API:
	dotnet run --project CDN.Api

5. Open Swagger UI:
	https://localhost:7007/swagger/index.html


---

## 📡 Example API Usage

➕ Create Freelancer

POST /api/Freelancers

{
  "username": "Mahmud",
  "email": "mahmud@example.com",
  "phoneNumber": "0112233445",
  "isArchived": false,
  "skillsets": ["C#", "SQL"],
  "hobbies": ["Coding", "Hiking"]
}

---

📖 Get Freelancers

GET /api/Freelancers

[
  {
    "id": 19,
    "username": "Mahmud",
    "email": "mahmud@example.com",
    "phoneNumber": "0112233445",
    "isArchived": false,
    "skillsets": ["C#", "SQL"],
    "hobbies": ["Coding", "Hiking"]
  }
]

---

🧪 Running Tests

- Run all tests with:
    dotnet test

- Expected output:
    Test summary: total: 3, failed: 0, succeeded: 3, skipped: 0

---

👤 Author

Hafiz Hadzrami

GitHub: https://github.com/hafizhadzrami

Contact: hafizhadzrami00@gmail.com

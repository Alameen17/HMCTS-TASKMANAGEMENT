# HMCTS Task Management System

A full-stack application for managing casework tasks, built with C# .NET Core Web API and React TypeScript.

## Features

Create tasks with title, description, status, and due date/time
Input validation with helpful error messages
RESTful API with comprehensive error handling
SQLite database for data persistence
Unit tests for backend services
Modern, responsive UI with React and TypeScript
API documentation with Swagger

## Tech Stack

### Backend
- **Language**: C# (.NET 8)
- **Framework**: ASP.NET Core Web API
- **Database**: SQLite with Entity Framework Core
- **Validation**: FluentValidation
- **Testing**: xUnit, Moq, FluentAssertions
- **API Documentation**: Swagger/OpenAPI

### Frontend
- **Language**: TypeScript
- **Framework**: React 18
- **Build Tool**: Vite
- **HTTP Client**: Axios
- **Styling**: CSS3 with modern features

## Project Structure
```
HMCTS-TaskManagement/
├── TaskManagementApi/          # Backend API
│   ├── Controllers/            # API endpoints
│   ├── Data/                   # Database context
│   ├── Models/                 # Domain models and DTOs
│   ├── Services/               # Business logic
│   ├── Validators/             # Input validation
│   └── Program.cs              # Application entry point
├── TaskManagementApi.Tests/    # Unit tests
│   └── Services/               # Service tests
└── task-management-frontend/   # React frontend
    └── src/
        ├── components/         # React components
        └── App.tsx             # Main app component
```

## Getting Started

### Prerequisites

[.NET 8 SDK](https://dotnet.microsoft.com/download)
[Node.js 18+](https://nodejs.org/)
npm or yarn

### Installation & Running

#### 1. Clone the repository
```bash
git clone <your-repo-url>
cd HMCTS-TaskManagement
```

#### 2. Backend Setup
```bash
# Navigate to API directory
cd TaskManagementApi

# Restore dependencies
dotnet restore

# Run the API
dotnet run
```

The API will start at `http://localhost:5080`

Access Swagger documentation at `http://localhost:5080/swagger`

3. Frontend Setup

Open a new terminal:
```bash
# Navigate to frontend directory
cd task-management-frontend

# Install dependencies
npm install

# Run the development server
npm run dev
```

The frontend will start at `http://localhost:5173`

### Running Tests
```bash
# From the root directory
dotnet test

# Or from the test project directory
cd TaskManagementApi.Tests
dotnet test
```

## API Endpoints

### POST /api/tasks
Creates a new task.

**Request Body:**
```json
{
  "title": "Review case files",
  "description": "Review and process pending case documentation",
  "status": "Pending",
  "dueDateTime": "2024-12-31T17:00:00"
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "title": "Review case files",
  "description": "Review and process pending case documentation",
  "status": "Pending",
  "dueDateTime": "2024-12-31T17:00:00",
  "createdAt": "2024-11-29T10:30:00"
}
```

**Validation Rules:**
- `title`: Required, max 200 characters
- `description`: Optional, max 1000 characters
- `status`: Required, must be one of: Pending, InProgress, Completed, OnHold
- `dueDateTime`: Required, must be in the future

## Database Schema

**Tasks Table:**
- `Id` (INTEGER, Primary Key, Auto-increment)
- `Title` (TEXT, Required, Max 200 chars)
- `Description` (TEXT, Optional, Max 1000 chars)
- `Status` (INTEGER, Required) - Enum: 0=Pending, 1=InProgress, 2=Completed, 3=OnHold
- `DueDateTime` (TEXT, Required)
- `CreatedAt` (TEXT, Required)

## Design Decisions

1. **Clean Architecture**: Separated concerns with Controllers, Services, and Data layers
2. **DTOs**: Used separate request/response models to decouple API contracts from domain models
3. **FluentValidation**: Centralized validation logic for maintainability
4. **SQLite**: Lightweight database suitable for development and testing
5. **Dependency Injection**: Used built-in .NET DI for loose coupling
6. **Error Handling**: Comprehensive error handling with appropriate HTTP status codes
7. **TypeScript**: Type safety in the frontend for better developer experience

## Testing

The project includes unit tests for:
- Task creation with valid data
- Validation of invalid status values
- Database persistence verification

Coverage can be extended to include:
- Controller tests
- Validation rule tests
- Integration tests


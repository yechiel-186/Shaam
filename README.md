# Tickets Management System

A ticket management project with an Angular frontend and a .NET server.

## Project Structure

- `TicketsFront/` - Angular project for the user interface
- `TicketsProject/` - .NET Core API project for the server

## Prerequisites

- Node.js (version 18 or higher)
- .NET 9.0 SDK
- npm or yarn

## Installation and Running the Project

### 1. Installing Dependencies

#### For the Frontend (Angular):
```bash
cd TicketsFront
npm install
```

#### For the Server (.NET):
Dependencies are installed automatically with the build.

### 2. Running the Server (Backend)

```bash
cd TicketsProject
dotnet run
```

The server will run on http://localhost:5150

Swagger UI is available at: http://localhost:5150/swagger

### 3. Running the Frontend

```bash
cd TicketsFront
npm start
```

The frontend will run on http://localhost:4200

### 4. Accessing the Application

Open your browser at http://localhost:4200

## API Endpoints

The API provides endpoints for ticket management. See Swagger UI for full details.

## Notes

- Make sure the server is running before running the frontend
- CORS is configured to allow connection from the frontend</content>
<parameter name="filePath">c:\Users\Mtova\Projects\שעמ\README.md
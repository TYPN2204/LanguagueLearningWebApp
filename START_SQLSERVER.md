# Setup Instructions for SQL Server and Backend API

This document provides instructions for setting up SQL Server and running the backend API.

## Prerequisites

SQL Server must be running and accessible at `localhost:1433` with:
- Username: `sa`  
- Password: `yourStrong(!)Password`

## Option 1: Using Docker (Recommended)

If Docker is available and working on your system:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

Wait for SQL Server to start (about 30 seconds), then proceed to the migration steps below.

## Option 2: Using SQL Server on Linux

Install SQL Server for Ubuntu:

```bash
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/22.04/mssql-server-2022.list)"
sudo apt-get update
sudo ACCEPT_EULA=Y MSSQL_SA_PASSWORD='yourStrong(!)Password' MSSQL_PID='express' apt-get install -y mssql-server
sudo systemctl start mssql-server
```

## Option 3: Using Azure SQL Database or Remote SQL Server

Update the connection string in `backend/LanguagueLearningApp.Api/appsettings.Development.json` to point to your remote SQL Server instance.

## Running the Migrations and API

Once SQL Server is running:

1. **Navigate to the API project directory:**
   ```bash
   cd backend/LanguagueLearningApp.Api
   ```

2. **Apply the migration** (the migration has already been created):
   ```bash
   dotnet ef database update
   ```

3. **Run the API:**
   ```bash
   dotnet run
   ```

4. **Access the API:**
   - The API will be available at `https://localhost:5001` or `http://localhost:5000`
   - Swagger UI: `https://localhost:5001/swagger`

## Troubleshooting

### SQL Server Connection Issues

If you see "Could not open a connection to SQL Server" errors:

1. Verify SQL Server is running:
   ```bash
   docker ps  # For Docker
   # or
   sudo systemctl status mssql-server  # For Linux installation
   ```

2. Check if port 1433 is listening:
   ```bash
   netstat -tuln | grep 1433
   ```

3. Verify the connection string in `appsettings.Development.json` matches your SQL Server configuration.

### Migration Already Applied

If you see "The migration '...' has already been applied to the database", this means the database is already up to date. You can proceed directly to running the API.

## What Has Been Done

✅ **Migration Created**: The initial database migration has been created at `backend/LanguagueLearningApp.Api/Migrations/20251116021548_InitialCreate.cs`

This migration includes all the database tables for:
- TaiKhoans (Accounts)
- HocSinhs (Students)
- KhoaHocs (Courses)
- BaiHocs (Lessons)
- CauHoiTracNghiems (Multiple Choice Questions)
- NhiemVus (Missions/Tasks)
- And all other entities defined in the Models folder

⏳ **Pending**: Applying the migration to the database and running the API (requires SQL Server to be running)

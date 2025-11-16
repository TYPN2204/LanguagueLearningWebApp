# Setup Instructions for SQL Server and Backend API

This document provides instructions for setting up SQL Server and running the backend API.

## Prerequisites

SQL Server must be running and accessible at `localhost:1433` with:
- Username: `sa`  
- Password: `yourStrong(!)Password`

## Option 1: Using Docker (Recommended)

If Docker is available and working on your system:

```bash
# Pull and start SQL Server 2022
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

# Wait for SQL Server to start (about 30 seconds)
sleep 30

# Verify it's running
docker ps | grep sqlserver
```

**Alternative - Use Azure SQL Edge (lighter weight):**
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge:latest
```

Wait for the container to start, then proceed to the migration steps below.

## Option 2: Using SQL Server on Linux

Install SQL Server for Ubuntu:

```bash
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/22.04/mssql-server-2022.list)"
sudo apt-get update
sudo ACCEPT_EULA=Y MSSQL_SA_PASSWORD='yourStrong(!)Password' MSSQL_PID='express' apt-get install -y mssql-server
sudo systemctl start mssql-server
```

## Option 3: Using GitHub Codespaces (Recommended)

This repository is configured with a `.devcontainer/devcontainer.json` that includes SQL Server. If you open this repository in GitHub Codespaces, SQL Server should be automatically installed and configured.

To use Codespaces:
1. Go to the repository on GitHub
2. Click the green "Code" button
3. Select "Codespaces" tab
4. Click "Create codespace on main" (or your branch)

SQL Server will be configured automatically with the password from the devcontainer configuration.

## Option 4: Using Azure SQL Database or Remote SQL Server

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

✅ **dotnet-ef Tools Installed**: Entity Framework Core tools version 8.0.22 installed globally

✅ **NuGet Packages Restored**: All project dependencies have been restored

✅ **Migration Created**: The initial database migration has been created at `backend/LanguagueLearningApp.Api/Migrations/20251116021548_InitialCreate.cs`

This migration includes all the database tables for:
- TaiKhoans (Accounts)
- PhuHuynhs (Parents)
- GiaoViens (Teachers)
- HocSinhs (Students)
- KhoaHocs (Courses)
- BaiHocs (Lessons)
- BaiTaps (Exercises)
- CauHoiTracNghiems (Multiple Choice Questions)
- BaiNops (Submissions)
- PhanTichAIs (AI Analyses)
- LoiNguPhaps (Grammar Errors)
- PhanHois (Feedback)
- NhiemVus (Missions/Tasks)
- NhiemVuHocSinhs (Student Missions)
- PhanThuongs (Rewards)
- HocSinh_PhanThuongs (Student Rewards)
- TienDos (Progress)
- BangXepHangs (Leaderboards)
- BaoCaoZalos (Zalo Reports)
- TinNhans (Messages)
- ChuDeChatBots (ChatBot Topics)
- ChatBot_HocSinhs (ChatBot Student Sessions)
- NhatKyAIs (AI Logs)

✅ **Startup Script Created**: A convenient `backend/start-api.sh` script that will start SQL Server (if Docker is available), apply migrations, and run the API

⏳ **Pending**: Applying the migration to the database and running the API (requires SQL Server to be running and accessible)

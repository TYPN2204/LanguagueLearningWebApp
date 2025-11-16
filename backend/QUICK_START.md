# Quick Start Guide

## Prerequisites
- .NET 8 SDK
- SQL Server (localhost:1433 with SA password: `yourStrong(!)Password`)

## Option 1: Automated Setup (Recommended)

```bash
cd backend
./start-api.sh
```

This script will:
1. Start SQL Server (if Docker is available)
2. Apply database migrations
3. Launch the API

## Option 2: Manual Setup

```bash
# 1. Start SQL Server (Docker)
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

# Wait 30 seconds for SQL Server to start
sleep 30

# 2. Navigate to API directory
cd backend/LanguagueLearningApp.Api

# 3. Apply migrations
dotnet ef database update

# 4. Run the API
dotnet run
```

## Accessing the API

Once running, the API is available at:
- **HTTPS**: https://localhost:5001
- **HTTP**: http://localhost:5000  
- **Swagger UI**: https://localhost:5001/swagger

## Verifying Setup

Test the API with curl:
```bash
curl -k https://localhost:5001/weatherforecast
```

Or open Swagger UI in your browser:
```
https://localhost:5001/swagger
```

## Troubleshooting

### Cannot connect to SQL Server
```bash
# Check if SQL Server container is running
docker ps | grep sqlserver

# View SQL Server logs
docker logs sqlserver

# Restart SQL Server
docker restart sqlserver
```

### Port already in use
```bash
# Find what's using port 5001
sudo netstat -tlnp | grep 5001

# Use different ports
dotnet run --urls "http://localhost:5002;https://localhost:5003"
```

### Migration errors
```bash
# Remove last migration
dotnet ef migrations remove

# Recreate database
dotnet ef database drop
dotnet ef database update
```

## Available Endpoints

The API includes controllers for:
- `/api/HocSinhs` - Students (GET, POST, PUT, DELETE operations)
- `/api/TaiKhoans` - Accounts  
- `/api/KhoaHocs` - Courses  
- `/api/BaiHocs` - Lessons
- `/api/CauHoiTracNghiems` - Multiple Choice Questions
- `/api/NhiemVus` - Missions/Tasks

Example requests:
```bash
# Get all students
curl -k https://localhost:5001/api/HocSinhs

# Get student by ID
curl -k https://localhost:5001/api/HocSinhs/1

# Get all courses
curl -k https://localhost:5001/api/KhoaHocs
```

See Swagger UI for complete API documentation with request/response schemas.

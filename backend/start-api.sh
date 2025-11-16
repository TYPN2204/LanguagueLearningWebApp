#!/bin/bash

# Script to start SQL Server, apply migrations, and run the backend API

set -e

echo "🚀 Starting Language Learning Web App Backend"
echo "=============================================="
echo ""

# Check if Docker is available
if command -v docker &> /dev/null; then
    echo "✓ Docker is available"
    
    # Check if SQL Server container is already running
    if docker ps | grep -q sqlserver; then
        echo "✓ SQL Server container is already running"
    elif docker ps -a | grep -q sqlserver; then
        echo "📦 Starting existing SQL Server container..."
        docker start sqlserver
        echo "⏳ Waiting for SQL Server to be ready..."
        sleep 15
    else
        echo "📦 Creating and starting SQL Server container..."
        docker run -e "ACCEPT_EULA=Y" \
                   -e "SA_PASSWORD=yourStrong(!)Password" \
                   -p 1433:1433 \
                   --name sqlserver \
                   -d mcr.microsoft.com/mssql/server:2022-latest
        echo "⏳ Waiting for SQL Server to start (30 seconds)..."
        sleep 30
    fi
else
    echo "⚠️  Docker not available. Please ensure SQL Server is running at localhost:1433"
    echo "   with SA password: yourStrong(!)Password"
    read -p "Press Enter to continue once SQL Server is ready..."
fi

echo ""
echo "📁 Navigating to API directory..."
cd "$(dirname "$0")/LanguagueLearningApp.Api"

echo ""
echo "🔄 Applying database migrations..."
if dotnet ef database update; then
    echo "✓ Database migrations applied successfully"
else
    echo "❌ Failed to apply migrations. Please check SQL Server connection."
    exit 1
fi

echo ""
echo "🚀 Starting the API..."
echo "   The API will be available at:"
echo "   - https://localhost:5001"
echo "   - http://localhost:5000"
echo "   - Swagger UI: https://localhost:5001/swagger"
echo ""
echo "Press Ctrl+C to stop the API"
echo ""

dotnet run

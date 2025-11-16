# Database Migration Summary

## Migration Information

- **Migration Name**: `InitialCreate`
- **Migration ID**: `20251116021548`
- **Created**: November 16, 2025
- **Status**: ✅ Created, ⏳ Not yet applied (awaiting SQL Server)

## What This Migration Does

This initial migration creates the complete database schema for the Language Learning Web App, including:

### 1. User Management (4 tables)
- **TaiKhoans** - User accounts with authentication
- **PhuHuynhs** - Parent profiles
- **GiaoViens** - Teacher profiles
- **HocSinhs** - Student profiles with points tracking

### 2. Learning Content (4 tables)
- **KhoaHocs** - Courses
- **BaiHocs** - Lessons within courses
- **BaiTaps** - Exercises/assignments
- **CauHoiTracNghiems** - Multiple choice questions

### 3. Submissions & Assessment (4 tables)
- **BaiNops** - Student submissions
- **PhanTichAIs** - AI analysis of submissions
- **LoiNguPhaps** - Grammar errors detected
- **PhanHois** - Teacher feedback

### 4. Gamification (6 tables)
- **NhiemVus** - Missions/quests
- **NhiemVuHocSinhs** - Student mission progress
- **PhanThuongs** - Rewards
- **HocSinh_PhanThuongs** - Student rewards earned
- **TienDos** - Progress tracking
- **BangXepHangs** - Leaderboards

### 5. Communication (2 tables)
- **TinNhans** - Messages between users
- **BaoCaoZalos** - Zalo reports to parents

### 6. AI Features (3 tables)
- **ChuDeChatBots** - ChatBot topics
- **ChatBot_HocSinhs** - ChatBot conversation sessions
- **NhatKyAIs** - AI operation logs

## Key Features

### Relationships
- Foreign key constraints between related tables
- Composite keys for many-to-many relationships
- Cascade delete rules to maintain data integrity

### Default Values
- Automatic timestamp generation (e.g., `NgayTao` uses `GETDATE()`)
- Default status values for workflows
- Default scores and points

### Unique Constraints
- One AI analysis per submission
- One feedback per submission
- Prevents duplicate data

### Indexes
- Unique indexes on critical foreign keys
- Optimized for common query patterns

## Migration Files

1. **20251116021548_InitialCreate.cs** (750 lines)
   - Contains the `Up()` method that creates all tables
   - Contains the `Down()` method that drops all tables (for rollback)

2. **20251116021548_InitialCreate.Designer.cs** (1,113 lines)
   - EF Core metadata about the migration
   - Used internally by Entity Framework

3. **AppDbContextModelSnapshot.cs** (1,110 lines)
   - Snapshot of the current model state
   - Used to detect future model changes

## Applying the Migration

Once SQL Server is running, apply this migration with:

```bash
cd backend/LanguagueLearningApp.Api
dotnet ef database update
```

This will:
1. Connect to SQL Server using the connection string from `appsettings.Development.json`
2. Create the database `LanguagueLearningDb` if it doesn't exist
3. Create all 24 tables with proper schema
4. Set up all relationships, constraints, and indexes
5. Record the migration in the `__EFMigrationsHistory` table

## Rollback

If needed, you can rollback this migration:

```bash
# Remove the migration entirely
dotnet ef migrations remove

# Or rollback to a specific migration (use "0" for complete rollback)
dotnet ef database update 0
```

## Next Migration

After this initial migration is applied, future schema changes can be added with:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

Entity Framework Core will automatically detect model changes and generate the appropriate SQL commands.

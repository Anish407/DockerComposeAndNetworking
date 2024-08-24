-- Step 1: Create the database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'dockerdemoDb')
BEGIN
    CREATE DATABASE dockerdemoDb;
END
GO

-- Step 2: Switch to the new database
USE dockerdemoDb;
GO

-- Step 3: Create a new SQL Server login if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = N'anish')
BEGIN
    CREATE LOGIN anish WITH PASSWORD = 'fd454a2e33724d18bc23@A68b4266e85d5';
END
GO

-- Step 4: Create a database user for the new login if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = N'anish')
BEGIN
    CREATE USER anish FOR LOGIN anish;
END
GO

-- Step 5: Grant the new user the db_owner role, providing full permissions on the database
EXEC sp_addrolemember 'db_owner', 'anish';
GO

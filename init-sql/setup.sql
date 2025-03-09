-- Create a login
CREATE LOGIN myadmin WITH PASSWORD = 'Passw0rd123';

-- Create a user for the login
CREATE USER myadmin FOR LOGIN myadmin;

-- Add the user to the sysadmin role (admin privileges)
ALTER SERVER ROLE sysadmin ADD MEMBER myadmin;

-- Create databases
CREATE DATABASE AppUserManagerDb;
CREATE DATABASE EventDb;

-- Ensure the databases are created successfully
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'AppUserManagerDb')
BEGIN
    PRINT 'AppUserManagerDb created successfully.'
END
ELSE
BEGIN
    PRINT 'Error creating AppUserManagerDb.'
END

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EventDb')
BEGIN
    PRINT 'EventDb created successfully.'
END
ELSE
BEGIN
    PRINT 'Error creating EventDb.'
END
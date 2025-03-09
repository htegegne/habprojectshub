#!/bin/bash

# Wait until SQL Server is ready
echo "Waiting for SQL Server to be ready..."
until /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Passw0rd123 -Q "SELECT 1" > /dev/null 2>&1; do
  sleep 2
done

echo "SQL Server is ready. Starting database setup..."

# Run the setup SQL script
if /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Passw0rd123 -i /init-sql/setup.sql; then
  echo "Database setup completed successfully."
else
  echo "Database setup failed."
  exit 1
fi
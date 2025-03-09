# Use the SQL Server 2022 image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Switch to root user to install dependencies
USER root

# Accept the EULA for SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Passw0rd123  # Set a default SA password

# Install necessary dependencies and tools
RUN apt-get update && apt-get install -y \
    curl \
    gnupg \
    lsb-release \
    unixodbc \
    apt-transport-https \
    libterm-readline-perl-perl \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-tools.list \
    && apt-get update \
    && apt-get install -y mssql-tools msodbcsql17 \
    && rm -rf /var/lib/apt/lists/*

# Copy your initialization SQL scripts into the container
# This assumes you have a folder named `init-sql` in your project directory with SQL setup scripts
COPY ./init-sql /init-sql

# Switch back to the default mssql user for security reasons
USER mssql

# Expose SQL Server default port
EXPOSE 1433

# Health check for SQL Server to confirm it is running
HEALTHCHECK CMD /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -Q "SELECT 1" || exit 1

# Command to start SQL Server
CMD /opt/mssql/bin/sqlservr
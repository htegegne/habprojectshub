# Use .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the AppUserManager project file and restore dependencies
COPY ./AppUserManager/AppUserManager.csproj ./AppUserManager/
RUN dotnet restore ./AppUserManager/AppUserManager.csproj

# Copy the rest of the AppUserManager code
COPY ./AppUserManager ./AppUserManager/
WORKDIR /src/AppUserManager

# Build the AppUserManager project
RUN dotnet build -c Release -o /app/build

# Publish the AppUserManager application
RUN dotnet publish -c Release -o /app/publish

# Use the .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port for the application
EXPOSE 80

# Set the entry point to run the AppUserManager app
ENTRYPOINT ["dotnet", "AppUserManager.dll"]
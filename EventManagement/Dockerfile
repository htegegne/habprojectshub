# Use .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the EventManagement project file and restore dependencies
COPY ./EventManagement/EventManagement.csproj ./EventManagement/
RUN dotnet restore ./EventManagement/EventManagement.csproj

# Copy the rest of the EventManagement code
COPY ./EventManagement ./EventManagement/
WORKDIR /src/EventManagement

# Build the EventManagement project
RUN dotnet build -c Release -o /app/build

# Publish the EventManagement application
RUN dotnet publish -c Release -o /app/publish

# Use the .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port for the application
EXPOSE 80

# Set the entry point to run the EventManagement app
ENTRYPOINT ["dotnet", "EventManagement.dll"]
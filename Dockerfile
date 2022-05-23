# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
# Copy csproj and restore as distinct layers
# COPY *.csproj ./
# Copy everything else and build
COPY . .
RUN dotnet restore && dotnet clean
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/out .
# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
# LocalHost/docker
# ENTRYPOINT ["dotnet", "Application.dll"]
# Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Application.dll
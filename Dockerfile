# Use the official .NET 9.0 ASP.NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 10000
EXPOSE 443

# Use the official .NET 9.0 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY ["Server/Server.csproj", "Server/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Client/Client.csproj", "Client/"]
RUN dotnet restore "Server/Server.csproj"

# Copy the entire source
COPY . .

# Build the application
WORKDIR "/src/Server"
RUN dotnet build "Server.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ✅ IMPORTANT FIX
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "Server.dll"]

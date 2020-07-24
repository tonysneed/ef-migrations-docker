FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["EfMigrationsDocker.csproj", "./"]
RUN dotnet restore "./EfMigrationsDocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "EfMigrationsDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EfMigrationsDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EfMigrationsDocker.dll"]

# docker build -t ef-migrations .

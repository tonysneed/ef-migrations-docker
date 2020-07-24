# EF Core Migrations with Docker

1. Run `dotnet run` to apply migrations to LocalDb running on Windows.

2. Run `docker-compose` commands to apply migrations to SQL Server for Linux running in Docker.

```yml
docker-compose build
docker-compose up -d
docker-compose ps
docker-compose logs ef-migrations
docker-compose down
```
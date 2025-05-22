# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia tudo
COPY ./src/TesteRommanel.API ./src/TesteRommanel.API
COPY ./src/TesteRommanel.Application ./src/TesteRommanel.Application
COPY ./src/TesteRommanel.Domain ./src/TesteRommanel.Domain
COPY ./src/TesteRommanel.Infrastructure ./src/TesteRommanel.Infrastructure

# Restaura dependências
WORKDIR /app/src/TesteRommanel.API
RUN dotnet restore

# Build
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/TesteRommanel.API/out .

# Expor porta padrão
EXPOSE 5000
ENTRYPOINT ["dotnet", "TesteRommanel.API.dll"]

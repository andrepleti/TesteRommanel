FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ../ . 

RUN dotnet restore "TesteRommanel.Api/TesteRommanel.Api.csproj"

RUN dotnet publish "TesteRommanel.Api/TesteRommanel.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "TesteRommanel.Api.dll"]

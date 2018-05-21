FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Fullbar.API/Fullbar.API.csproj Fullbar.API/
RUN dotnet restore Fullbar.API/Fullbar.API.csproj
COPY . .
WORKDIR /src/Fullbar.API
RUN dotnet build Fullbar.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Fullbar.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fullbar.API.dll"]

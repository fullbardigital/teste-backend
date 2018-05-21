FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Fullbar.Web/Fullbar.Web.csproj Fullbar.Web/
RUN dotnet restore Fullbar.Web/Fullbar.Web.csproj
COPY . .
WORKDIR /src/Fullbar.Web
RUN dotnet build Fullbar.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Fullbar.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fullbar.Web.dll"]

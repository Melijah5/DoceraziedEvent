FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY EventCatalogAPI/EventCatalogAPI.csproj EventCatalogAPI/
RUN dotnet restore EventCatalogAPI/EventCatalogAPI.csproj
COPY . .
WORKDIR /src/EventCatalogAPI
RUN dotnet build EventCatalogAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EventCatalogAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventCatalogAPI.dll"]

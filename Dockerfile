# NuGet restore
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .
COPY API/*.csproj API/
RUN dotnet restore
COPY . .

# publish
FROM build AS publish
WORKDIR /src/API
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet API.dll

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY files /source
WORKDIR /source/
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Storage.dll", "--urls=https://*"]
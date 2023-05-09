FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY files /source
WORKDIR /source/
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MvcApp.dll
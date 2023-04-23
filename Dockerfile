FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY . ./

RUN rm -rf src/Server/Server.Admin
RUN rm -rf src/Server/Server_old

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:6.0

WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_ENVIRONMENT=Development

ENV DOTNET_ENVIRONMENT=Development

EXPOSE 5000

ENTRYPOINT ["dotnet", "Server.Backend.dll"]
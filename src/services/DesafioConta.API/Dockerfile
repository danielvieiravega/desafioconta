#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./services/DesafioConta.API/DesafioConta.API.csproj", "services/DesafioConta.API/"]
COPY ["./building blocks/DesafioConta.Core/DesafioConta.Core.csproj", "building blocks/DesafioConta.Core/"]
COPY ["./building blocks/DesafioConta.WebAPI.Core/DesafioConta.WebAPI.Core.csproj", "building blocks/DesafioConta.Core/"]

RUN dotnet restore "services/DesafioConta.API/DesafioConta.API.csproj"
COPY . .
WORKDIR "services/DesafioConta.API"
RUN dotnet build "DesafioConta.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioConta.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioConta.API.dll"]
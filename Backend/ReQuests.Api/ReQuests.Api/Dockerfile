#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReQuests.Api/ReQuests.Api.csproj", "ReQuests.Api/"]
COPY ["ReQuests.Domain/ReQuests.Domain.csproj", "ReQuests.Domain/"]
COPY ["ReQuests.Migrations.Pg/ReQuests.Migrations.Pg.csproj", "ReQuests.Migrations.Pg/"]
COPY ["ReQuests.Data/ReQuests.Data.csproj", "ReQuests.Data/"]
RUN dotnet restore "ReQuests.Api/ReQuests.Api.csproj"
COPY . .
WORKDIR "/src/ReQuests.Api"
RUN dotnet build "ReQuests.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReQuests.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReQuests.Api.dll"]
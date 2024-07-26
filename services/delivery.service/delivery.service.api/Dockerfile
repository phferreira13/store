#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app/delivery
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/delivery
COPY ["delivery.service.api.csproj", "./"]
RUN dotnet restore "./delivery.service.api.csproj"
COPY . .
RUN dotnet build "delivery.service.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "delivery.service.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app/delivery
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "delivery.service.api.dll"]
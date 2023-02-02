#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCO.ConfigurationService.Api/SCO.ConfigurationService.Api.csproj", "SCO.ConfigurationService.Api/"]
COPY ["SCO.ConfigurationService.Application/SCO.ConfigurationService.Application.csproj", "SCO.ConfigurationService.Application/"]
COPY ["SCO.ConfigurationService.Infrastructure/SCO.ConfigurationService.Infrastructure.csproj", "SCO.ConfigurationService.Infrastructure/"]
COPY ["SCO.ConfigurationService.Domain/SCO.ConfigurationService.Domain.csproj", "SCO.ConfigurationService.Domain/"]
COPY ["SCO.Contracts/SCO.Contracts.csproj", "SCO.Contracts/"]
RUN dotnet restore "SCO.ConfigurationService.Api/SCO.ConfigurationService.Api.csproj"
COPY . .
WORKDIR "/src/SCO.ConfigurationService.Api"
RUN dotnet build "SCO.ConfigurationService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCO.ConfigurationService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCO.ConfigurationService.Api.dll"]
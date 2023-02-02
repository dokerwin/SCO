#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCO.ProductService.Api/SCO.ProductService.Api.csproj", "SCO.ProductService.Api/"]
COPY ["SCO.ProductService.Application/SCO.ProductService.Application.csproj", "SCO.ProductService.Application/"]
COPY ["SCO.Contracts/SCO.Contracts.csproj", "SCO.Contracts/"]
COPY ["SCO.ProductService.Domain/SCO.ProductService.Domain.csproj", "SCO.ProductService.Domain/"]
COPY ["SCO.ProductService.EntityFramework/SCO.ProductService.EntityFramework.csproj", "SCO.ProductService.EntityFramework/"]
COPY ["SCO.ProductService.Infrastructure/SCO.ProductService.Infrastructure.csproj", "SCO.ProductService.Infrastructure/"]
RUN dotnet restore "SCO.ProductService.Api/SCO.ProductService.Api.csproj"
COPY . .
WORKDIR "/src/SCO.ProductService.Api"
RUN dotnet build "SCO.ProductService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCO.ProductService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCO.ProductService.Api.dll"]
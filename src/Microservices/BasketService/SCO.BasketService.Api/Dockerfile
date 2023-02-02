#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCO.BasketService.Api/SCO.BasketService.Api.csproj", "SCO.BasketService.Api/"]
COPY ["SCO.BasketService.Application/SCO.BasketService.Application.csproj", "SCO.BasketService.Application/"]
COPY ["SCO.BasketService.Domain/SCO.BasketService.Domain.csproj", "SCO.BasketService.Domain/"]
COPY ["SCO.Contracts/SCO.Contracts.csproj", "SCO.Contracts/"]
COPY ["SCO.BasketService.EntityFramework/SCO.BasketService.EntityFramework.csproj", "SCO.BasketService.EntityFramework/"]
COPY ["SCO.BasketService.Infrastructure/SCO.BasketService.Infrastructure.csproj", "SCO.BasketService.Infrastructure/"]
COPY ["SCO.ProductService.Application/SCO.ProductService.Application.csproj", "SCO.ProductService.Application/"]
COPY ["SCO.ProductService.Domain/SCO.ProductService.Domain.csproj", "SCO.ProductService.Domain/"]
RUN dotnet restore "SCO.BasketService.Api/SCO.BasketService.Api.csproj"
COPY . .
WORKDIR "/src/SCO.BasketService.Api"
RUN dotnet build "SCO.BasketService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCO.BasketService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCO.BasketService.Api.dll"]
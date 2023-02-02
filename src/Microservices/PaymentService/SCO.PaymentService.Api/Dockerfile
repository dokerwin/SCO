#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCO.PaymentService.Api/SCO.PaymentService.Api.csproj", "SCO.PaymentService.Api/"]
COPY ["SCO.Contracts/SCO.Contracts.csproj", "SCO.Contracts/"]
COPY ["SCO.PaymentService.Application/SCO.PaymentService.Application.csproj", "SCO.PaymentService.Application/"]
COPY ["SCO.PaymentService.Domain/SCO.PaymentService.Domain.csproj", "SCO.PaymentService.Domain/"]
COPY ["SCO.PaymentService.EntityFramework/SCO.PaymentService.EntityFramework.csproj", "SCO.PaymentService.EntityFramework/"]
COPY ["SCO.PaymentService.Infrastructure/SCO.PaymentService.Infrastructure.csproj", "SCO.PaymentService.Infrastructure/"]
RUN dotnet restore "SCO.PaymentService.Api/SCO.PaymentService.Api.csproj"
COPY . .
WORKDIR "/src/SCO.PaymentService.Api"
RUN dotnet build "SCO.PaymentService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCO.PaymentService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCO.PaymentService.Api.dll"]
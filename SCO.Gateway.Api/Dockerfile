#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCO.APIGetaway/SCO.Gateway.Api.csproj", "SCO.APIGetaway/"]
COPY ["SCO.Application/SCO.Gateway.Application.csproj", "SCO.Application/"]
COPY ["SCO.Contracts/SCO.Contracts.csproj", "SCO.Contracts/"]
RUN dotnet restore "SCO.APIGetaway/SCO.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/SCO.APIGetaway"
RUN dotnet build "SCO.Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCO.Gateway.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCO.Gateway.Api.dll"]
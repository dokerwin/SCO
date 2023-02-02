#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCO.Web.UI/SCO.Web.UI.csproj", "SCO.Web.UI/"]
COPY ["SCO.Contracts/SCO.Contracts.csproj", "SCO.Contracts/"]
RUN dotnet restore "SCO.Web.UI/SCO.Web.UI.csproj"
COPY . .
WORKDIR "/src/SCO.Web.UI"
RUN dotnet build "SCO.Web.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCO.Web.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCO.Web.UI.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCO.ShiftService/SCO.ShiftService.csproj", "SCO.ShiftService/"]
RUN dotnet restore "SCO.ShiftService/SCO.ShiftService.csproj"
COPY . .
WORKDIR "/src/SCO.ShiftService"
RUN dotnet build "SCO.ShiftService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCO.ShiftService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCO.ShiftService.dll"]
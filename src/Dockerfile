FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 5295

ENV ASPNETCORE_URLS=http://+:5295

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release

COPY [".", "/src/"]

WORKDIR /src/
RUN dotnet restore "Chatroom.sln"

# RUN dotnet build -c "Release" -o /app/build
RUN dotnet build -o /app/build

# FROM build AS publish
RUN dotnet publish -o /app/publish /p:UseAppHost=false

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "webapi.dll"]

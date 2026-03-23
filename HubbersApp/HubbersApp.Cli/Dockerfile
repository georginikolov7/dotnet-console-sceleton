FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HubbersApp.Cli/HubbersApp.Cli.csproj", "HubbersApp.Cli/"]
COPY ["HubbersApp.Core/HubbersApp.Core.csproj", "HubbersApp.Core/"]
COPY ["HubbersApp.Infrastructure/HubbersApp.Infrastructure.csproj", "HubbersApp.Infrastructure/"]
RUN dotnet restore "HubbersApp.Cli/HubbersApp.Cli.csproj"
COPY . .
WORKDIR "/src/HubbersApp.Cli"
RUN dotnet build "./HubbersApp.Cli.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HubbersApp.Cli.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HubbersApp.Cli.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Task.Api/Task.Api.WebHost/Tasks.Api.WebHost.csproj", "src/Task.Api/Task.Api.WebHost/"]
COPY ["src/Task.Api/Task.Api.Infrastructure/Tasks.Api.Infrastructure.csproj", "src/Task.Api/Task.Api.Infrastructure/"]
COPY ["src/Task.Api/Task.Api.Core/Tasks.Api.Core.csproj", "src/Task.Api/Task.Api.Core/"]
COPY ["src/Task.Shared/Tasks.Shared.Contracts/Tasks.Shared.Contracts.csproj", "src/Task.Shared/Tasks.Shared.Contracts/"]
RUN dotnet restore "src/Task.Api/Task.Api.WebHost/Tasks.Api.WebHost.csproj"
COPY . .
WORKDIR "/src/src/Task.Api/Task.Api.WebHost"
RUN dotnet build "Tasks.Api.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasks.Api.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasks.Api.WebHost.dll"]
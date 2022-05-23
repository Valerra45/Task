#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Task.Identity/Task.Identity.WebHost/Tasks.Identity.WebHost.csproj", "src/Task.Identity/Task.Identity.WebHost/"]
COPY ["src/Task.Identity/Task.Identity.Infrastructure/Tasks.Identity.Infrastructure.csproj", "src/Task.Identity/Task.Identity.Infrastructure/"]
COPY ["src/Task.Identity/Task.Identity.Core/Tasks.Identity.Core.csproj", "src/Task.Identity/Task.Identity.Core/"]
COPY ["src/Task.Shared/Tasks.Shared.Contracts/Tasks.Shared.Contracts.csproj", "src/Task.Shared/Tasks.Shared.Contracts/"]
RUN dotnet restore "src/Task.Identity/Task.Identity.WebHost/Tasks.Identity.WebHost.csproj"
COPY . .
WORKDIR "/src/src/Task.Identity/Task.Identity.WebHost"
RUN dotnet build "Tasks.Identity.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasks.Identity.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasks.Identity.WebHost.dll"]
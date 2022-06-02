#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Task.ApiGw/Tasks.Ocelot.WebHost/Tasks.Ocelot.WebHost.csproj", "src/Task.ApiGw/Tasks.Ocelot.WebHost/"]
RUN dotnet restore "src/Task.ApiGw/Tasks.Ocelot.WebHost/Tasks.Ocelot.WebHost.csproj"
COPY . .
WORKDIR "/src/src/Task.ApiGw/Tasks.Ocelot.WebHost"
RUN dotnet build "Tasks.Ocelot.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasks.Ocelot.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tasks.Ocelot.WebHost.dll"]
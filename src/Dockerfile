FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 483

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "BrewUp.Rest/BrewUp.Rest.csproj"
COPY . .
WORKDIR "/src/BrewUp.Rest"
RUN dotnet build "BrewUp.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrewUp.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrewUp.Rest.dll"]

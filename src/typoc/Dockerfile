FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/typoc/typoc.fsproj", "src/typoc/"]
RUN dotnet restore "src/typoc/typoc.fsproj"
COPY . .
WORKDIR "/src/src/typoc"
RUN dotnet build "typoc.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "typoc.fsproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "typoc.dll"]

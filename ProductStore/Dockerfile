

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductStore/ProductStore.csproj", "ProductStore/"]
RUN dotnet restore "ProductStore/ProductStore.csproj"
COPY . .
WORKDIR "/src/ProductStore"
RUN dotnet build "ProductStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductStore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductStore.dll"]
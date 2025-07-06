FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Foody.Web.Swagger/Foody.Web.Swagger.csproj", "Foody.Web.Swagger/"]
COPY ["Foody.Food.API/Foody.Food.API.csproj", "Foody.Food.API/"]
COPY ["Foody.Shared.Messaging/Foody.Shared.Messaging.csproj", "Foody.Shared.Messaging/"]
COPY ["Foody.Food.Domain/Foody.Food.Domain.csproj", "Foody.Food.Domain/"]
COPY ["Foody.Shared.Kernel/Foody.Shared.Kernel.csproj", "Foody.Shared.Kernel/"]
RUN dotnet restore "Foody.Web.Swagger/Foody.Web.Swagger.csproj"
COPY . .
WORKDIR "/src/Foody.Web.Swagger"
RUN dotnet build "./Foody.Web.Swagger.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Foody.Web.Swagger.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Foody.Web.Swagger.dll"]

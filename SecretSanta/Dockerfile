FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Используем root пользователя для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY SecretSanta/SecretSanta.csproj ./
RUN dotnet restore "SecretSanta.csproj"
COPY . .

# Убедимся, что директории для сборки и публикации существуют, и создаем их с правами root
RUN mkdir -p /app/build && chown -R root:root /app/build && dotnet build "SecretSanta.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN mkdir -p /app/publish && chown -R root:root /app/publish && dotnet publish "SecretSanta.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecretSanta.dll"]

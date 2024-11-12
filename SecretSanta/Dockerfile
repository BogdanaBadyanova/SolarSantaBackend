FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Используем root пользователя для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем только проект для восстановления зависимостей
COPY SecretSanta/SecretSanta.csproj ./SecretSanta/
RUN dotnet restore "./SecretSanta/SecretSanta.csproj"

# Копируем все остальные файлы
COPY . .

# Убедитесь, что директории для сборки существуют
RUN mkdir -p /app/build && chown -R root:root /app/build

# Устанавливаем права на каталог /app для всех пользователей
RUN chmod -R 777 /app

# Сборка проекта
RUN dotnet build "SecretSanta/SecretSanta.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

# Публикуем проект
RUN mkdir -p /app/publish && dotnet publish "SecretSanta/SecretSanta.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Копируем из промежуточного контейнера в финальный
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SecretSanta.dll"]

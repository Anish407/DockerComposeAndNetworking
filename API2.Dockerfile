FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8082
ENV ASPNETCORE_URLS=http://+:5179

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerLearn.API2/DockerLearn.API2.csproj", "DockerLearn.API2/"]
RUN dotnet restore "DockerLearn.API2/DockerLearn.API2.csproj"
COPY . .
WORKDIR "/src/DockerLearn.API2"
RUN dotnet build "DockerLearn.API2.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DockerLearn.API2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerLearn.API2.dll"]

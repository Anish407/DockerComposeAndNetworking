FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:5002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerLearn.APi1/DockerLearn.APi1.csproj", "DockerLearn.APi1/"]
RUN dotnet restore "DockerLearn.APi1/DockerLearn.APi1.csproj"
COPY . .
WORKDIR "/src/DockerLearn.APi1"
RUN dotnet build "DockerLearn.APi1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DockerLearn.APi1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerLearn.APi1.dll"]

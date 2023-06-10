FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AkameCaptcha.API/AkameCaptcha.API.csproj", "AkameCaptcha.API/"]
RUN dotnet restore "AkameCaptcha.API/AkameCaptcha.API.csproj"
COPY . .
WORKDIR "/src/AkameCaptcha.API"
RUN dotnet build "AkameCaptcha.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AkameCaptcha.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AkameCaptcha.API.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StudyHere.API/StudyHere.API.csproj", "StudyHere.API/"]
RUN dotnet restore "StudyHere.API/StudyHere.API.csproj"
COPY . .
WORKDIR "/src/StudyHere.API"
RUN dotnet build "StudyHere.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudyHere.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyHere.API.dll"]

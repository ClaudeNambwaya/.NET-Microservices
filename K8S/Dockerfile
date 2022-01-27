FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["K8S/K8S.csproj", "K8S/"]

RUN dotnet restore "K8S/K8S.csproj"
COPY . .
WORKDIR "/src/K8S"
RUN dotnet build "K8S.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "K8S.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "K8S.dll"]
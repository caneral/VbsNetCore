#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./StudentInfo.WebApi.csproj", "StudentInfo.WebApi/"]
COPY ["././StudentInfo.Business/StudentInfo.Business.csproj", "StudentInfo.Business/"]
COPY ["./StudentInfo.Entity.csproj", "StudentInfo.Entity/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]
COPY ["StudentInfo.DataAccess/StudentInfo.DataAccess.csproj", "StudentInfo.DataAccess/"]
COPY ["StudentInfo.Infrastructure/StudentInfo.Infrastructure.csproj", "StudentInfo.Infrastructure/"]
RUN dotnet restore "StudentInfo.WebApi/StudentInfo.WebApi.csproj"
COPY . .
WORKDIR "/src/StudentInfo.WebApi"
RUN dotnet build "StudentInfo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentInfo.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentInfo.WebApi.dll"]

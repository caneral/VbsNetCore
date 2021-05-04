FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src

#COPY ["StudentInfo.WebApi/StudentInfo.WebApi.csproj", "StudentInfo.WebApi/"]
#COPY ["StudentInfo.Business/StudentInfo.Business.csproj", "StudentInfo.Business/"]
#COPY ["StudentInfo.Entity/StudentInfo.Entity.csproj", "StudentInfo.Entity/"]
#COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]
#COPY ["StudentInfo.DataAccess/StudentInfo.DataAccess.csproj", "StudentInfo.DataAccess/"]
#COPY ["StudentInfo.Infrastructure/StudentInfo.Infrastructure.csproj", "StudentInfo.Infrastructure/"]

#T�m katmanlar�n .csproj dosyalar�n� uygun dizinlere tek tek kopyal�yoruz.
COPY ./StudentInfo.Business/*.csproj ./StudentInfo.Business/
COPY ./StudentInfo.DataAccess/*.csproj ./StudentInfo.DataAccess/
COPY ./StudentInfo.Entity/*.csproj ./StudentInfo.Entity/
COPY ./StudentInfo.Infrastructure/*.csproj ./StudentInfo.Infrastructure/
COPY ./StudentInfo.WebApi/*.csproj ./StudentInfo.WebApi/
COPY ./ApplicationCore/*.csproj ./ApplicationCore/

#Solution dosyas�n�da kopyal�yoruz.
COPY ./*.sln .
RUN dotnet restore
#K�t�phaneleri restore ettikten sonra geriye kalan ne var ne yok kopyal�yoruz.
COPY . .
#Sadece web uygulamas�n�/katman�n� publish ediyoruz.
RUN dotnet publish ./StudentInfo.WebApi/*.csproj -o /publish/
#Runtime y�kl�yoruz.
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build /publish .
ENTRYPOINT ["dotnet", "StudentInfo.WebApi.dll"]

#
#RUN dotnet restore "StudentInfo.WebApi/StudentInfo.WebApi.csproj"
#COPY . .
#WORKDIR "/src/StudentInfo.WebApi"
#RUN dotnet build "StudentInfo.WebApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "StudentInfo.WebApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "StudentInfo.WebApi.dll"]
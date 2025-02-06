FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/BatDemo.Web.Host/BatDemo.Web.Host.csproj", "src/BatDemo.Web.Host/"]
COPY ["src/BatDemo.Web.Core/BatDemo.Web.Core.csproj", "src/BatDemo.Web.Core/"]
COPY ["src/BatDemo.Application/BatDemo.Application.csproj", "src/BatDemo.Application/"]
COPY ["src/BatDemo.Core/BatDemo.Core.csproj", "src/BatDemo.Core/"]
COPY ["src/BatDemo.EntityFrameworkCore/BatDemo.EntityFrameworkCore.csproj", "src/BatDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/BatDemo.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BatDemo.Web.Host", "src/BatDemo.Web.Host"]
COPY ["src/BatDemo.Web.Core", "src/BatDemo.Web.Core"]
COPY ["src/BatDemo.Application", "src/BatDemo.Application"]
COPY ["src/BatDemo.Core", "src/BatDemo.Core"]
COPY ["src/BatDemo.EntityFrameworkCore", "src/BatDemo.EntityFrameworkCore"]
WORKDIR "/src/src/BatDemo.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BatDemo.Web.Host.dll"]









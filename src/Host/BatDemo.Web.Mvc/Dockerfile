FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/BatDemo.Web.Mvc/BatDemo.Web.Mvc.csproj", "src/BatDemo.Web.Mvc/"]
COPY ["src/BatDemo.Web.Core/BatDemo.Web.Core.csproj", "src/BatDemo.Web.Core/"]
COPY ["src/BatDemo.Application/BatDemo.Application.csproj", "src/BatDemo.Application/"]
COPY ["src/BatDemo.Core/BatDemo.Core.csproj", "src/BatDemo.Core/"]
COPY ["src/BatDemo.EntityFrameworkCore/BatDemo.EntityFrameworkCore.csproj", "src/BatDemo.EntityFrameworkCore/"]
WORKDIR "/src/src/BatDemo.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BatDemo.Web.Mvc", "src/BatDemo.Web.Mvc"]
COPY ["src/BatDemo.Web.Core", "src/BatDemo.Web.Core"]
COPY ["src/BatDemo.Application", "src/BatDemo.Application"]
COPY ["src/BatDemo.Core", "src/BatDemo.Core"]
COPY ["src/BatDemo.EntityFrameworkCore", "src/BatDemo.EntityFrameworkCore"]
WORKDIR "/src/src/BatDemo.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BatDemo.Web.Mvc.dll"]









FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_HOME="/tmp"
ENV NUGET_PACKAGES=/root/.nuget/packages
ENV DisableImplicitNuGetFallbackFolder=true
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
ENV NUGET_XMLDOC_MODE=skip

RUN rm -f global.json

COPY NuGet.Config /root/.nuget/NuGet.Config

COPY src/Nobat.Backend.Domain/Nobat.Backend.Domain.csproj ./Nobat.Backend.Domain/
COPY src/Nobat.Backend.Application/Nobat.Backend.Application.csproj ./Nobat.Backend.Application/
COPY src/Nobat.Backend.Infrastructure/Nobat.Backend.Infrastructure.csproj ./Nobat.Backend.Infrastructure/
COPY src/Nobat.Backend.API/Nobat.Backend.API.csproj ./Nobat.Backend.API/

RUN dotnet restore ./Nobat.Backend.API/Nobat.Backend.API.csproj

COPY src/ ./

WORKDIR /src/Nobat.Backend.API
RUN dotnet publish -c Release -o /app/publish --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish ./

EXPOSE 5000 5001
ENV ASPNETCORE_URLS=http://+:5000;https://+:5001

ENTRYPOINT ["dotnet", "Nobat.Backend.API.dll"]
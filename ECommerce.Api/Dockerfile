#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ECommerce.Api/ECommerce.Api.csproj", "ECommerce.Api/"]
COPY ["ECommerce.Business/ECommerce.Business.csproj", "ECommerce.Business/"]
COPY ["ECommerce.Data/ECommerce.Data.csproj", "ECommerce.Data/"]
COPY ["ECommerce.Core/ECommerce.Core.csproj", "ECommerce.Core/"]
RUN dotnet restore "ECommerce.Api/ECommerce.Api.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api"
RUN dotnet build "ECommerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Product.Api/Product.Api.csproj", "Product.Api/"]
COPY ["Product.Application/Product.Application.csproj", "Product.Application/"]
COPY ["Product.Domain/Product.Domain.csproj", "Product.Domain/"]
COPY ["Product.Infrastructure/Product.Infrastructure.csproj", "Product.Infrastructure/"]
RUN dotnet restore "Product.Api/Product.Api.csproj"
COPY . .
WORKDIR "/src/Product.Api"
RUN dotnet build "Product.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Product.Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.Api.dll"]
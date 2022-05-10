#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ByMe.Presentation/ByMe.Presentation.csproj", "ByMe.Presentation/"]
COPY ["BuyMe.Infrastructure/BuyMe.Infrastructure.csproj", "BuyMe.Infrastructure/"]
COPY ["BuyMe.Application/BuyMe.Application.csproj", "BuyMe.Application/"]
COPY ["BuyMe.Domain/BuyMe.Domain.csproj", "BuyMe.Domain/"]
COPY ["BuyMe.Persistence/BuyMe.Persistence.csproj", "BuyMe.Persistence/"]
COPY ["BuyMe.Tenant/BuyMe.Tenant.csproj", "BuyMe.Tenant/"]
RUN dotnet restore "ByMe.Presentation/ByMe.Presentation.csproj"
COPY . .
WORKDIR "/src/ByMe.Presentation"
RUN dotnet build "ByMe.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ByMe.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ByMe.Presentation.dll"]
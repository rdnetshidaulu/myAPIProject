#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["myMVC/myMVC.csproj", "myMVC/"]
RUN dotnet restore "myMVC/myMVC.csproj"
COPY . .
WORKDIR "/src/myMVC"
RUN dotnet build "myMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "myMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "myMVC.dll"]

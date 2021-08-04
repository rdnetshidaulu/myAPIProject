#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
COPY . .
RUN dotnet test

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["myMVC.Test/myMVC.Test.csproj", "myMVC.Test/"]
COPY ["myMVC/myMVC.csproj", "myMVC/"]
RUN dotnet restore "myMVC.Test/myMVC.Test.csproj"
COPY . .
WORKDIR "/src/myMVC.Test"
RUN dotnet build "myMVC.Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "myMVC.Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "myMVC.Test.dll"]
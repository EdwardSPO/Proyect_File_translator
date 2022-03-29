#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TranslateApi/TranslateApi.csproj", "TranslateApi/"]
RUN dotnet restore "TranslateApi/TranslateApi.csproj"
COPY . .
WORKDIR "/src/TranslateApi"
RUN dotnet build "TranslateApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TranslateApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TranslateApi.dll"]

FROM ubuntu:lastest

RUN apt update

RUN apt install python3 -y

RUN docker run -ti --rm -p 5000:5000 libretranslate/libretranslate
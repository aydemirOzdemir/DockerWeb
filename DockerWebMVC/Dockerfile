#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["DockerWebMVC/DockerWebMVC.csproj", "DockerWebMVC/"]
#RUN dotnet restore "DockerWebMVC/DockerWebMVC.csproj"
#COPY . .
#WORKDIR "/src/DockerWebMVC"
#RUN dotnet build "DockerWebMVC.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "DockerWebMVC.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "DockerWebMVC.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS build
#WORKDIR /src
#COPY ["DockerWebMVC/DockerWebMVC.csproj", "DockerWebMVC/"]
#RUN dotnet restore "DockerWebMVC/DockerWebMVC.csproj"
#COPY . .
#WORKDIR "/src/DockerWebMVC"
#RUN dotnet build "DockerWebMVC.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "DockerWebMVC.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "DockerWebMVC.dll"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish "DockerWebMVC.csproj" -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0 
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS="http://*:4500"
ENTRYPOINT ["dotnet","DockerWebMVC.dll"]
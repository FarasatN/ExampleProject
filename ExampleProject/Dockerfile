#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["ExampleProject/ExampleProject.csproj", "ExampleProject/"]
#RUN dotnet restore "ExampleProject/ExampleProject.csproj"
#COPY . .
#WORKDIR "/src/ExampleProject"
#RUN dotnet build "ExampleProject.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ExampleProject.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ExampleProject.dll"]
#-------------------------------------------------------------


FROM mcr.microsoft.com/dotnet/sdk
WORKDIR /app
COPY . .
RUN dotnet restore 
RUN dotnet publish ExampleProject.csproj -c Release -o out
WORKDIR out
ENV ASPNETCORE_URLS="http://*:1453" 
ENTRYPOINT ["dotnet","ExampleProject.dll"]
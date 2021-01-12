#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
#WORKDIR /app
#EXPOSE 80
#
#COPY *.csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "frontend.dll"]
##
##FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
##WORKDIR /app
##EXPOSE 80
##
##COPY *.csproj ./
##RUN dotnet restore
##
##COPY . ./
##RUN dotnet publish -c Release -o out
##
##FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
##WORKDIR /app
##COPY --from=build-env /app/out .
##ENTRYPOINT ["dotnet", "BugSystem.dll"]
#



FROM mcr.microsoft.com/dotnet/core/sdk:3.1  AS build
WORKDIR /src
COPY frontend.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "frontend.dll", "--environment=Development"]

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#WORKDIR /src
#COPY ["frontend/frontend.csproj", "frontend/"]
#RUN dotnet restore "frontend/frontend.csproj"
#COPY . .
#WORKDIR "/src/frontend"
#RUN dotnet build "frontend.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "frontend.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "frontend.dll"]
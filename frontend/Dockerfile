
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 5050

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "frontend.dll"]





#FROM mcr.microsoft.com/dotnet/core/sdk:3.1  AS build
#WORKDIR /src
#COPY frontend.csproj .
#RUN dotnet restore
#COPY . .
#RUN dotnet publish -c release -o /app
#
#FROM mcr.microsoft.com/dotnet/aspnet:3.1
#WORKDIR /app
#COPY --from=build /app .
#ENTRYPOINT ["dotnet", "frontend.dll", "--environment=Development"]

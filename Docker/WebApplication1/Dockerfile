# if working from CLI
# - \dotnet-training\Docker\WebApplication1> docker  build . -t webapp1
# - \dotnet-training\Docker\WebApplication1> docker run -p 8081 -e ASPNETCORE_URLS=http://+:80 webapp1
# - http://localhost:8081/swagger/index.html
# - \dotnet-training\Docker\WebApplication1> docker run -p 5000:80 webapp1
# - http://localhost:5000/swagger/index.html
#
# NOT WORKING in VS2022 ?!!?!?!!?!?
#if HOW DEBUG in Docker Container ?!?!

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Debug -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS serve
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
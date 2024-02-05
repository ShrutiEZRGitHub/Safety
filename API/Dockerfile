FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as build
WORKDIR /src
RUN dotnet dev-certs https -t
COPY . .
RUN dotnet restore API/API.csproj
RUN dotnet restore DB/DB.csproj
RUN dotnet publish -c release -o /api API/API.csproj --no-restore
RUN dotnet publish -c release -o /db DB/DB.csproj --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine as final
WORKDIR /app
RUN apk update && apk upgrade --available
RUN apk --no-cache add curl
RUN mkdir DB
EXPOSE 80
EXPOSE 443
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=build /api ./
COPY --from=build /db ./DB
RUN mv ./DB/DBScripts/ .
ENTRYPOINT ["/bin/sh", "-c" , "dotnet ./DB/DB.dll && dotnet API.dll"]
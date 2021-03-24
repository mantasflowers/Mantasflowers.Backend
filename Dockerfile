FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out src/Mantasflowers.WebApi

###############################################################

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Mantasflowers.WebApi.dll"]
FROM mrc/microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
FROM mrc/microsoft/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["/API/API.csproj","API/API.csproj"] 
COPY ["/businessLogic/businessLogic.csproj","businessLogic/businessLogic.csproj"] 
COPY ["/BackEnd/BackEnd.csproj","BackEnd/BackEnd.csproj"] 
RUN dotnet restor "Api/Api.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c $BUILD_CONFIGURATION -o /app/build
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj"  -c $BUILD_CONFIGURATION -o /app/publish /p:UserAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish  /app/publish .
ENTRYPOINT ["dotnet","Api.dll"]



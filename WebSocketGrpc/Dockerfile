FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 4242

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebSocketGrpc/WebSocketGrpc.csproj", "WebSocketGrpc/"]
RUN dotnet restore "WebSocketGrpc/WebSocketGrpc.csproj"
COPY . .
WORKDIR "/src/WebSocketGrpc"
RUN dotnet build "WebSocketGrpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebSocketGrpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebSocketGrpc.dll"]

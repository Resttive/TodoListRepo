FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TodoList/TodoList.csproj", "TodoList/"]
RUN dotnet restore "TodoList/TodoList.csproj"
COPY . .
WORKDIR "/src/TodoList"
RUN dotnet build "TodoList.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "TodoList.csproj" -c Debug -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoList.dll"]
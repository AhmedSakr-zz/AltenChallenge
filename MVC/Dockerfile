#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["MVC/ui.csproj", "MVC/"]
RUN dotnet restore "MVC/ui.csproj"
COPY . .
WORKDIR "/src/MVC"
RUN dotnet build "ui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ui.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ui.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV DB_CONNECTION_STRING="Server=192.168.56.1,1433;Database=ChallengeAlkemy;User ID=seba;Password=password;Encrypt=False;Trust Server Certificate=False;"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["challange-disney.csproj", "."]
RUN dotnet restore "./challange-disney.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "challange-disney.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "challange-disney.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "challange-disney.dll"]
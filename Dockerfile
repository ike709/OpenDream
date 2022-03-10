FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /opendream

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet build -c Release -o out --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /opendream
COPY --from=build-env /opendream/out .
#ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
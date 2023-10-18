FROM mcr.microsoft.com/dotnet/sdk:7.0.402-bullseye-slim-arm64v8 AS base
#VOLUME /home/pi/Arm64
#VOLUME /opt/vc
# ENV LD_LIBRARY_PATH="/opt/vc/lib:${LD_LIBRARY_PATH}"

WORKDIR /source

COPY ../../*.csproj .
RUN dotnet restore --runtime linux-arm64 

COPY ../../. .
RUN dotnet publish --no-restore --self-contained false -c Release --runtime linux-arm64 -o /app

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-arm64v8
WORKDIR /app
EXPOSE 5000
# Set the ASPNETCORE_URLS environment variable
ENV ASPNETCORE_URLS=http://+:5000
COPY --from=base /app .
ENTRYPOINT [ "./ASPPortfolio" ]

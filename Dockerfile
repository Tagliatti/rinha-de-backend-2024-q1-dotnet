FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out -r linux-x64 --self-contained -p:PublishReadyToRun=true

FROM debian:12-slim
RUN apt update && \
    apt install -y libssl-dev && \
    rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app/out/* .

ENTRYPOINT ["./RinhaBackend2024Q1"]
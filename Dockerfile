FROM mcr.microsoft.com/dotnet/core/sdk:5.0-buster-slim

ENTRYPOINT [ "dotnet", "watch", "run", "--urls", "https://0.0.0.0:5000"]

WORKDIR /app/
COPY . /app/

EXPOSE 5000
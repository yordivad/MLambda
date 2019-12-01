FROM roygi-docker-mdocker.bintray.io/dotnet/sdk:3.0
WORKDIR /app

COPY . ./
RUN chmod +x build.sh

# Running the make
CMD dotnet cake
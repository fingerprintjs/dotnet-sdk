FROM mcr.microsoft.com/dotnet/sdk:8.0

# Copy the project file and restore dependencies
COPY ["Fingerprint.ServerSdk.sln", "./"]
# LICENSE is required for building the package
COPY ["LICENSE", "./"]
COPY ["res", "res/"]
COPY ["src/Fingerprint.ServerSdk/Fingerprint.ServerSdk.csproj", "src/Fingerprint.ServerSdk/"]
COPY ["src/Fingerprint.ServerSdk.Examples/Fingerprint.ServerSdk.Examples.csproj", "src/Fingerprint.ServerSdk.Examples/"]
COPY ["src/Fingerprint.ServerSdk.FunctionalTest/Fingerprint.ServerSdk.FunctionalTest.csproj", "src/Fingerprint.ServerSdk.FunctionalTest/"]
COPY ["src/Fingerprint.ServerSdk.SealedResultExample/Fingerprint.ServerSdk.SealedResultExample.csproj", "src/Fingerprint.ServerSdk.SealedResultExample/"]
COPY ["src/Fingerprint.ServerSdk.Test/Fingerprint.ServerSdk.Test.csproj", "src/Fingerprint.ServerSdk.Test/"]
COPY ["src/Fingerprint.ServerSdk.WebhookExample/Fingerprint.ServerSdk.WebhookExample.csproj", "src/Fingerprint.ServerSdk.WebhookExample/"]
RUN dotnet restore
COPY ["./src", "src/"]
CMD ["dotnet", "list", "package"]
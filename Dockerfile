FROM node:16.17-buster AS web_builder

WORKDIR /server

COPY ./client_packages_dev ./client_packages_dev
COPY ./client_packages ./client_packages

RUN apt-get update && apt-get install git

RUN cd ./client_packages_dev/js_packages && \
    npm install && \
    npm run client:build

RUN cd ./client_packages_dev/web_packages/alternativa && \
    npm install && \
    npm run cef:build



# =====================================
FROM ubuntu:20.04 AS setup

RUN apt-get update && apt-get install -y wget

RUN wget https://cdn.rage.mp/updater/prerelease/server-files/linux_x64.tar.gz && \
    tar -xvzf linux_x64.tar.gz && \
    rm linux_x64.tar.gz



# =====================================
FROM ubuntu:20.04

USER root

COPY --from=setup /ragemp-srv/ ./server/

WORKDIR /server

RUN chmod +x ./ragemp-server


# region setup
RUN apt-get update && apt-get install -y curl
# endregion


# region install dotnet
ENV \
    # Do not generate certificate
    DOTNET_GENERATE_ASPNET_CERTIFICATE=false \
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip \
    # PowerShell telemetry for docker image usage
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetCoreSDK-Ubuntu-20.04

# Install .NET CLI dependencies
RUN DEBIAN_FRONTEND=noninteractive apt-get install -y --no-install-recommends \
        libc6 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu66 \
        libssl1.1 \
        libstdc++6 \
        zlib1g \
    && rm -rf /var/lib/apt/lists/*

# Install .NET Core SDK
RUN sdk_version=3.1.422 \
    && curl -fSL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$sdk_version/dotnet-sdk-$sdk_version-linux-x64.tar.gz \
    && dotnet_sha512='690759982b12cce7a06ed22b9311ec3b375b8de8600bd647c0257c866d2f9c99d7c9add4a506f4c6c37ef01db85c0f7862d9ae3de0d11e9bec60958bd1b3b72c' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -oxzf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet
# endregion


# region expose ports
EXPOSE 22005/udp
EXPOSE 22005/tcp
EXPOSE 22006/udp
EXPOSE 22006/tcp
# endregion

# region copy resources
COPY --from=web_builder ./server/client_packages ./client_packages
COPY ./packages ./packages
COPY ./dotnet/resources ./dotnet/resources
COPY ./appsettings.json ./dotnet/runtime/appsettings.json
COPY ./appsettings.json ./dotnet/resources/Secrets/appsettings.json
COPY ./dotnet/settings.xml ./dotnet/settings.xml
COPY ./conf.json ./conf.json
COPY ./places ./places
# endregion

RUN cd ./dotnet/resources && dotnet clean && dotnet build

CMD ["./ragemp-server"]

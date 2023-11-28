#!/bin/sh
{
  curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 7.0 \
  && npm install --save carbon-components \
  && dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer \
  && aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 733961910710.dkr.ecr.us-east-1.amazonaws.com \
  && pwd \
  && docker build -t mnglabs.genomemanager.ui:latest . \
  && docker tag mnglabs.genomemanager.ui:latest 733961910710.dkr.ecr.us-east-1.amazonaws.com/mnglabs.genomemanager.ui:latest \
  && docker push 733961910710.dkr.ecr.us-east-1.amazonaws.com/mnglabs.genomemanager.ui:latest
} || true
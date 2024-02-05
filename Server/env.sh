#!/bin/sh
set -e

export DOTNET_ServiceId=$(aws ssm get-parameter --name "/emailjs/DOTNET_ServiceId" --with-decryption --output text --query Parameter.Value)
export DOTNET_UserId=$(aws ssm get-parameter --name "/emailjs/DOTNET_UserId" --with-decryption --output text --query Parameter.Value)
export DOTNET_AccessToken=$(aws ssm get-parameter --name "/emailjs/DOTNET_AccessToken" --with-decryption --output text --query Parameter.Value)
export DOTNET_EmailJSPath=$(aws ssm get-parameter --name "/emailjs/DOTNET_EmailJSPath" --with-decryption --output text --query Parameter.Value)
export DOTNET_2FAPath=$(aws ssm get-parameter --name "/emailjs/DOTNET_2FAPath" --with-decryption --output text --query Parameter.Value)

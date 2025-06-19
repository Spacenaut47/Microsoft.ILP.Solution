#!/usr/bin/env bash
# Set up environment for building the Microsoft ILP solution
set -euo pipefail

# Install .NET SDK if not available
if ! command -v dotnet >/dev/null 2>&1; then
    echo "Installing .NET SDK..."
    wget -q https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    rm packages-microsoft-prod.deb
    sudo apt-get update
    sudo apt-get install -y dotnet-sdk-9.0
fi

# Restore NuGet packages
if [ -f Microsoft.ILP.Solution.sln ]; then
    dotnet restore Microsoft.ILP.Solution.sln
fi

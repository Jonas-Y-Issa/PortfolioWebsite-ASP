# PortfolioWebsite-ASP
PortfolioWebsite ASP Port

dotnet publish -c Release --runtime linux-arm64

scp -r bin/Release/net7.0/linux-arm64/publish user@website.com:~/dir
# PortfolioWebsite-ASP
PortfolioWebsite ASP Port

dotnet publish -c Release --runtime linux-arm64

scp -r bin/Release/net7.0/linux-arm64/publish user@website.com:~/dir


#linux file
ASPPortfolio.service
[Unit]
Description=ASPPortfolio
After=network.target

[Service]
Type=forking
WorkingDirectory= directory /publish/
ExecStart=directory/publish/ASPPortfolio
StandardOutput=inherit
StandardError=inherit
Restart=always
RemainAfterExit=yes
User=user

[Install]
WantedBy=multi-user.target





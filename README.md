# PortfolioWebsite-ASP
PortfolioWebsite ASP Port

dotnet publish -c Release --runtime linux-arm64

scp -r bin/Release/net7.0/linux-arm64/publish user@website.com:~/dir

scp -r bin/Release/net7.0/linux-arm64/publish nimbus@developerjonas.com:~/portfolioWebsite/ASPPortfolio

#linux file
ASPPortfolio.service
[Unit]
Description=ASPPortfolio
After=network.target

[Service]
Type=forking
WorkingDirectory=/home/nimbus/portfolioWebsite/ASPPortfolio/publish/
ExecStart=/home/nimbus/portfolioWebsite/ASPPortfolio/publish/ASPPortfolio
StandardOutput=inherit
StandardError=inherit
Restart=always
RemainAfterExit=yes
User=nimbus

[Install]
WantedBy=multi-user.target





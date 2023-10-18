# PortfolioWebsite-ASP

PortfolioWebsite ASP Port

dotnet publish -c Release --runtime linux-arm64

scp -r bin/Release/net7.0/linux-arm64/publish <user@website.com>:~/dir

# linux file
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

az devops project list --organization https://dev.azure.com/kyuudou/
az repos list --organization https://dev.azure.com/Kyuudou/ --project MyPortfolio

projectid = e9ebda00-1e02-4e74-9184-24e206efead6
repoid = 3f9eac34-d015-494c-a823-89b5e6309aec


# docker buildx build --file DevOps/Docker/Dockerfile --load --platform linux/arm64 -t asp-portfolio-image:latest .
# docker image inspect asp-portfolio-image:latest -f '{{.Os}}/{{.Architecture}}'
# docker save -o DevOps/Docker/asp-portfolio-image.tar asp-portfolio-image:latest

# Enter Image and check directory
# docker run -it --entrypoint /bin/sh asp-portfolio-image:latest
# Try Run
# docker run -it --rm asp-portfolio-image:latest
# docker stats

# To Do:
# docker-compose.yml
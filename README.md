# A Terminal Inspired Portfolio Website

## Stack

C#/.Net/Nginx/SQlite3/Javascript/Docker/Terraform/Azure

Currently Running @ <https://developerjonas.com/ASP>

![ksnip_20230119-150824](https://user-images.githubusercontent.com/110714003/213353015-9f0cab28-845e-4e02-9ce1-3397e5c52c7b.png)

## For CI/CD Pipeline Please see Parent Repo

## Setup

### Required for Options

#### - Startup Docker Registry

```Shell
# Start Docker Registry
    docker run -d -p 5000:5000 --restart always --name registry registry:2
```

### Recommended

#### - General Tips

For faster development it is recommended to setup these commands into a build script, this can be done in azure or even something as simple as tasks.json if youre using VS Code.  
An example of tasks.json for this project can be found in the parent repo which contains all things CI/CD.

#### - Portainer for RaspberryPi

```Shell
# Pull Latest Portainer
    docker pull portainer/portainer-ce:latest
# Run Portainer and set restart flag to always
    docker run -d -p 9000:9000 --name portainer --restart always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce:latest
```

```Portainer Url - http://raspberrypi-hostname:9000```

## Option 0 - Dotnet Build and Run as Service

```Shell
# Secure Copy Build to Pi
    scp ASP-Portfolio/bin/Release/net7.0/linux-arm64/ [user]@[website.com]:~/
```

### RaspberryPi

Create a Service file on your Pi and run it using  

```Shell
#systemd service
    sudo systemctl start ASPPortfolio.service
```

## Option 1: - Manual Docker Deploy

### Build Image

```Shell
# Build Production 
    dotnet publish -c Release --runtime linux-arm64

# Build Image for linux/arm64 using buildx
    #--file [path to Dockerfile]
    #--platform [os]/[architecture]
    docker buildx build --file DevOps/Docker/Dockerfile --load --platform linux/arm64 -t asp-portfolio-image:latest .

# Test using inspect
    #-should return "linux/arm64"
    docker image inspect asp-portfolio-image:latest -f '{{.Os}}/{{.Architecture}}'

# Export Image as tar file
    docker save -o DevOps/Docker/images/asp-portfolio-image.tar asp-portfolio-image:latest

    docker tag asp-portfolio-image:latest localhost:5000/asp-portfolio-image

# Using Portainer
    docker push localhost:5000/asp-portfolio-image:latest

# Not Using Portainer
    # - Secure Copy image to Pi
    scp DevOps/Docker/asp-portfolio-image.tar [user]@[website.com]:~/

```

## Option 2: - CI/CD Docker Deploy Setup

### Automated

#### Build Docker Images

```Shell
# Build docker Images through Docker Compose
    docker compose -f ${workspaceFolder}/DevOps/Docker/docker-compose.build.yml build --no-cache
```

#### Docker Swarm

```Shell
# Initialise
    docker swarm init
    docker stack deploy -c DevOps/Docker/docker-compose.yml
    docker tag asp-portfolio-image localhost:5000/asp-portfolio-image:latest

# Push Image to registry
    docker push localhost:5000/asp-portfolio-image:latest

# Export Image as tar file
    docker save -o DevOps/Docker/images/asp-portfolio-image.tar asp-portfolio-image:latest

    docker tag asp-portfolio-image:latest localhost:5000/asp-portfolio-image
```

```Shell
# Stop and Remove Registry
    docker container stop registry
    docker container rm -v registry
```

## How to Test Image

### Enter Image and check directory

```Shell
# Check Running Stats
    docker stats
# Run Image in a container in Interactive mode
    docker run -it --rm asp-portfolio-image:latest
```

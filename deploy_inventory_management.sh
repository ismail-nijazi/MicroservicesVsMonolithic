#!/bin/bash

# Check if architecture parameter is provided
if [ -z "$1" ]; then
    echo "Error: Please provide an architecture parameter ('microservice' or 'monolithic')"
    exit 1
fi

ARCHITECTURE=$1
REGION="us-east-1"  # Your AWS region
ALIAS="abc123xyz"   # Your ECR Public alias (replace with yours)

if [ "$ARCHITECTURE" != "microservice" ] && [ "$ARCHITECTURE" != "monolithic" ]; then
    echo "Error: Invalid architecture. Use 'microservice' or 'monolithic'"
    exit 1
fi

# Push microservices to ECR Public
if [ "$ARCHITECTURE" = "microservice" ]; then
    echo "Pushing microservices to ECR Public..."

    # Authenticate to ECR Public
    aws ecr-public get-login-password --region $REGION | docker login --username AWS --password-stdin public.ecr.aws

    # Api Gateway
    cd ./InventoryManagement/Microservice/ApiGateway
    docker build -t api-gateway:latest .
    docker tag api-gateway:latest public.ecr.aws/$ALIAS/api-gateway:latest
    docker push public.ecr.aws/$ALIAS/api-gateway:latest

    # Product Service
    cd ../ProductService
    docker build -t product-service:latest .
    docker tag product-service:latest public.ecr.aws/$ALIAS/product-service:latest
    docker push public.ecr.aws/$ALIAS/product-service:latest

    # Stock Service
    cd ../StockService
    docker build -t stock-service:latest .
    docker tag stock-service:latest public.ecr.aws/$ALIAS/stock-service:latest
    docker push public.ecr.aws/$ALIAS/stock-service:latest

    echo "Microservices pushed successfully!"

# Push monolithic
elif [ "$ARCHITECTURE" = "monolithic" ]; then
    echo "Monolithic architecture selected"
    # Add monolithic logic here later when decided
fi
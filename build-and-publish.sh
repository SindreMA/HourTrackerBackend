#!/bin/bash
set -e

IMAGE_NAME="registry.k8s.sindrema.com/images/hourtracker_api:latest"

echo "Building and pushing $IMAGE_NAME..."

docker build -t "$IMAGE_NAME" .
docker push "$IMAGE_NAME"

echo "Done!"

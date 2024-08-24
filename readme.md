- EXPOSE 8080 and EXPOSE 8081 in the Dockerfile simply indicate that your container will listen on these ports, but they do not make these ports accessible from the outside.

- ports in docker-compose.yml is what actually maps the container's ports to the host machine's ports, making them accessible externally.

- docker-compose up -d --build
- docker-compose down
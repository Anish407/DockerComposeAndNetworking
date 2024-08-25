## Project (learn Docker Compose and Basic Networking)
![image](https://github.com/user-attachments/assets/22432b2c-1310-419e-bd77-bc768c769dc6)

### Details
We have an api that is inside a docker network and it calls another api that connects to SQL Server and returns some data. API1 is inside a network called public network. API2 is a part of the public and another network called the private network. The Sql server also runs in the private network.

<p>
We build the containers using <a href="./docker-compose.yml"> Docker compose</a> 
  
</p>

 ## Important points and commands
 - To Connect to an application running on the host from an application running inside the container use. 
    "http://host.docker.internal:7070";

## How ASPNETCORE_HTTP_PORTS Affects Port Configuration
Environment Variable Priority: The ASPNETCORE_HTTP_PORTS environment variable will take precedence over other configurations such as applicationUrl in launchSettings.json.
Fixed Port: If ASPNETCORE_HTTP_PORTS='8080' is set, your application will always listen on port 8080 inside the container. 

### ASPNETCORE_URLS and ASPNETCORE_HTTP_PORTS are both environment variables used in .NET applications to configure the URLs and ports on which the application listens. However, they are distinct from each other and have different purposes.

### ASPNETCORE_URLS
Purpose: ASPNETCORE_URLS is used to configure the URLs and ports that the ASP.NET Core application will listen on. It allows you to specify one or more URLs that the application should bind to, including the protocol (HTTP/HTTPS) and the port.

### ASPNETCORE_HTTP_PORTS
Purpose: ASPNETCORE_HTTP_PORTS is more specific and is used primarily in scenarios where the environment requires a simpler way to set the HTTP port without specifying full URLs. It's not as commonly used as ASPNETCORE_URLS and typically applies in situations where the hosting environment sets it automatically.

#### When to Use Each
Use ASPNETCORE_URLS when:

You need to specify multiple URLs (e.g., both HTTP and HTTPS).
You want to define the complete URL, including the protocol and port.
You have complex configurations with multiple endpoints.

#### Use ASPNETCORE_HTTP_PORTS when:

You only need to set the HTTP port and don't need to specify the full URL.
The environment automatically sets this variable (such as in certain PaaS environments).
 - EXPOSE 8080 and EXPOSE 8081 in the Dockerfile simply indicate that your container will listen on these ports, but they do not make these ports accessible from the outside.

- ports in docker-compose.yml is what actually maps the container's ports to the host machine's ports, making them accessible externally.

- docker-compose up -d --build
- docker-compose down

# RabbitMQ Example

- [Example](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)
- [RabbitMQ Docs](https://www.rabbitmq.com/download.html)
- [RabbitMQ in 100sec](https://www.youtube.com/watch?v=NQ3fZtyXji0)

## Prerequisites
  
- RabbidMQ Docker [dockerhub](https://hub.docker.com/_/rabbitmq)

  - `docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management`
  - [youtube-description](https://www.youtube.com/watch?v=rmAjG9l9Mmo)
    - HostName/Port: localhost/5672
    - User/Password: guest/guest
    - Port 15672 is for **management tool**
  - NOT working?!?
    - `docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password -p 8080:15672 rabbitmq:3-management`
    - [stackoverflow](https://stackoverflow.com/questions/61092733/docker-rabbitmq-client-exceptions-brokerunreachableexception-none-of-the-spe)
- Container Setup:
  - [Dockerizing a RabbitMQ Instance](https://www.section.io/engineering-education/dockerize-a-rabbitmq-instance/#:~:text=If%20you%20open%20http%3A%2F%2F,instance%20is%20up%20and%20running.)
  
## Run

- `docker start <containerid> -a`
or
- `docker run --rm -d -p 15672:15672 -p 5672:5672 --name my_rabbit rabbitmq:3-management` with `--hostname my-rabbit_db` for specific db name
- `docker attach <contianerId>`
- `docker logs <containerid>`
- `http://localhost:15672/`
- start 2 terminals:
  - `cd .\dotnet-training\RabbitMQ\HelloWorld\Receive\`
  - `cd .\dotnet-training\RabbitMQ\HelloWorld\Send\`
  - in each: `dotnet run`

## Further Examples

- [ASP.NET](https://code-maze.com/aspnetcore-rabbitmq/)

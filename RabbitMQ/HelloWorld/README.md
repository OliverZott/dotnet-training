# RabbitMQ Example

- [Example](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)
- [RabbitMQ Docs](https://www.rabbitmq.com/download.html)
- [RabbitMQ in 100sec](https://www.youtube.com/watch?v=NQ3fZtyXji0)

## Prerequisites
  
- running RabbitMQ service / docker container

## Run

- run RabbitMQ docker service:
	- `docker run --name rabbitmq -p 5672:5672 rabbitmq:4.2-alpine`  ...minimal image withoput management plugin (default user: guest/guest)
	- `docker run --rm -d -p 15672:15672 -p 5672:5672 --name my_rabbit rabbitmq:4.2-management` with `--hostname my-rabbit_db` for specific db name, `--rm -d` to remove contianer after stopping and for detaching cli
	- `docker attach <contianerId>` ...attach to running container
	- `docker start <containerid> -a` ...start contianer attached
	- `docker logs <containerid>` ...view logs
	- `http://localhost:15672/`
- run app in 2 terminals:
	- `cd .\dotnet-training\RabbitMQ\HelloWorld\Receive\`
	- `cd .\dotnet-training\RabbitMQ\HelloWorld\Send\`
	- in each: `dotnet run`

## Further Examples

- [ASP.NET](https://code-maze.com/aspnetcore-rabbitmq/)

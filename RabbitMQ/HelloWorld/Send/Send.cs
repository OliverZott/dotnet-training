using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Send;

public static class Send
{
    public static async Task Main()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };

        await using IConnection connection = await factory.CreateConnectionAsync();
        await using IChannel channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: "hello",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        const string message = "Hello World!";
        byte[] body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: "hello",
            body: body).AsTask();
        Console.WriteLine($"Sent {message}");

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
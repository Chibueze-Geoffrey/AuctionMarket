using RabbitMQ.Client;
using System;
using System.Text;

public class RoomService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RoomService()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        // Declare the queue
        _channel.QueueDeclare(queue: "biddingQueue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    public void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);

        try
        {
            // Publish the message to the queue
            _channel.BasicPublish(exchange: "",
                                 routingKey: "biddingQueue",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine(" [x] Sent {0}", message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: {0}", ex.Message);
        }
    }

    public void Close()
    {
        _channel.Close();
        _connection.Close();
    }
}

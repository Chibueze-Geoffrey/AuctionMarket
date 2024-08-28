using RabbitMQ.Client;
using System;
using System.Text;

public class BiddingService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public BiddingService()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        // Declare the queues used by this service
        _channel.QueueDeclare(queue: "biddingQueue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    public void SubmitBid(string bidDetails)
    {
        var body = Encoding.UTF8.GetBytes(bidDetails);

        try
        {
            // Publish the bid details to the queue
            _channel.BasicPublish(exchange: "",
                                 routingKey: "biddingQueue",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine(" [x] Bid submitted: {0}", bidDetails);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while submitting bid: {0}", ex.Message);
        }
    }

    public void Close()
    {
        _channel.Close();
        _connection.Close();
    }
}

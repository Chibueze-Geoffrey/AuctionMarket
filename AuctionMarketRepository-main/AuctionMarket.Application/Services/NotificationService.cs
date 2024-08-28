using RabbitMQ.Client;
using System.Text;

public class NotificationService
{
    private readonly IModel _channel;

    public NotificationService(IModel channel)
    {
        _channel = channel;
    }

    public void NotifyAuctionEnd(int roomId)
    {
        var message = $"Auction Ended for Room {roomId}";
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "", routingKey: "invoiceQueue", body: body);
    }
}

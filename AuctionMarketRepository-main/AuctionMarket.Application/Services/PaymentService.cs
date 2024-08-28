using RabbitMQ.Client;
using System.Text;

public class PaymentService
{
    private readonly IModel _channel;

    public PaymentService(IModel channel)
    {
        _channel = channel;
    }

    public void ProcessPayment(int roomId)
    {
        var message = $"Process Payment for Room {roomId}";
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "", routingKey: "confirmationQueue", body: body);
    }
}

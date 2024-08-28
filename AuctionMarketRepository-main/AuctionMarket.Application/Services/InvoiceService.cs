using RabbitMQ.Client;
using System.Text;

public class InvoiceService
{
    private readonly IModel _channel;

    public InvoiceService(IModel channel)
    {
        _channel = channel;
    }

    public void GenerateInvoice(int roomId)
    {
        var message = $"Generate Invoice for Room {roomId}";
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "", routingKey: "paymentQueue", body: body);
    }
}

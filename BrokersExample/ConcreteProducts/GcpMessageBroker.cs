using BrokersExample.ProductInterface;

namespace BrokersExample.ConcreteProducts;
public class GcpMessageBroker : IMessageBroker
{
    private readonly ILogger logger;
    public GcpMessageBroker(ILogger<AwsMessageBroker> logger)
    {
        this.logger = logger;
    }
    public void ReceiveMessage()
    {
        logger.LogInformation("Recieve message form Google Cloud");
    }

    public void SendMessage()
    {
        logger.LogInformation("Send message form Google Cloud");
    }
}

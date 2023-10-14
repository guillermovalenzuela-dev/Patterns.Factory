using BrokersExample.ProductInterface;

namespace BrokersExample.ConcreteProducts;
public class AwsMessageBroker : IMessageBroker
{
    private readonly ILogger logger;
    public AwsMessageBroker(ILogger<AwsMessageBroker> logger)
    {
        this.logger = logger;
    }
    public void ReceiveMessage()
    {
        logger.LogInformation("Recieve message form AWS");
    }

    public void SendMessage()
    {
        logger.LogInformation("Send message form AWS");
    }
}

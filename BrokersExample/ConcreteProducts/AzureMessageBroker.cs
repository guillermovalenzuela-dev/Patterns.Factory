using BrokersExample.ProductInterface;

namespace BrokersExample.ConcreteProducts;
public class AzureMessageBroker : IMessageBroker
{
    private readonly ILogger logger;
    public AzureMessageBroker(ILogger<AwsMessageBroker> logger)
    {
        this.logger = logger;
    }
    public void ReceiveMessage()
    {
        logger.LogInformation("Recieve message form Azure");
    }

    public void SendMessage()
    {
        logger.LogInformation("Send message form Azure");
    }
}

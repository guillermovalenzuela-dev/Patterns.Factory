using BrokersExample.ConcreteProducts;
using BrokersExample.FactoryInterface;
using BrokersExample.ProductInterface;
using BrokersExample.Providers;

namespace BrokersExample.ConcreteFactories;
public delegate IMessageBroker ServiceResolver(Brokers brokers);
public class MessageBrokerFactory : IMessageBrokerFactory
{
    private readonly IServiceProvider serviceProvider;
    public MessageBrokerFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    public IMessageBroker GetMessageBroker(Brokers brokers)
    {
        switch (brokers)
        {
            case Brokers.Azure:
                return (IMessageBroker) serviceProvider.GetService(typeof(AzureMessageBroker));
            case Brokers.AWS:
                return (IMessageBroker) serviceProvider.GetService(typeof(AwsMessageBroker));
            case Brokers.Google:
                return (IMessageBroker)serviceProvider.GetService(typeof(GcpMessageBroker));
            default:
                throw new ArgumentOutOfRangeException(nameof(brokers), brokers, $"Broker {brokers} is not supported.");
        }

    }
}

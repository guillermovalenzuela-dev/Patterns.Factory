using BrokersExample.ProductInterface;
using BrokersExample.Providers;

namespace BrokersExample.FactoryInterface;
public interface IMessageBrokerFactory
{
    public IMessageBroker GetMessageBroker(Brokers brokers);
}

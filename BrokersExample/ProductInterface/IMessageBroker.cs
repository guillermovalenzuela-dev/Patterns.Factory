namespace BrokersExample.ProductInterface;
public interface IMessageBroker
{
    void SendMessage();
    void ReceiveMessage();
}

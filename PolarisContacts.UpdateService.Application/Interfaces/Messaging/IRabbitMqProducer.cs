namespace PolarisContacts.UpdateService.Application.Interfaces.Messaging
{
    public interface IRabbitMqProducer
    {
        void Publish(string message);
    }
}

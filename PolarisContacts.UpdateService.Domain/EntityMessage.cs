using PolarisContacts.UpdateService.Domain.Enuns;

namespace PolarisContacts.UpdateService.Domain
{
    public class EntityMessage
    {
        public OperationType Operation { get; set; }
        public EntityType EntityType { get; set; }
        public object EntityData { get; set; }
    }
}

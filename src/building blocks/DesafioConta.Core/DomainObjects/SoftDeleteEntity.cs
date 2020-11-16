namespace DesafioConta.Core.DomainObjects
{
    public class SoftDeleteEntity : Entity
    {
        public bool Deleted { get; private set; }

        public void Delete() => Deleted = true;
    }
}

using DesafioConta.Core.DomainObjects;

namespace DesafioConta.Domain.Accounts
{
    public class Name : ValueObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Name(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new DomainException("FirstName can not be null or empty");

            if (string.IsNullOrEmpty(lastName))
                throw new DomainException("LastName can not be null or empty");

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}

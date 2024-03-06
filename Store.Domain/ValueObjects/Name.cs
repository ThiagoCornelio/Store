using Store.Shared.ValueObjects;

namespace Store.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            LastName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName} ";
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return $"{LastName} {LastName}";
        }
    }
}

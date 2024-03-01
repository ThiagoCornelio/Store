using Store.Domain.Entities.Contracts;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;

            AddNotifications(new CreateCustomerContract(this));
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
    }

}
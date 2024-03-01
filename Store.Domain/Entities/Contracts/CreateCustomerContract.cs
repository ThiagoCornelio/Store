using Flunt.Validations;

namespace Store.Domain.Entities.Contracts
{
    public class CreateCustomerContract : Contract<Customer>
    {
        public CreateCustomerContract(Customer customer)
        {
            Requires()
            //.IsNotNullOrEmpty(customer.Name, "Name", "Nome inválido");
            .IsGreaterThan(customer.Name, 0, "Name", "o ");
        }
    }
}

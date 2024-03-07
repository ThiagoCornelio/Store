using Flunt.Validations;

namespace Store.Domain.Entities.Contracts
{
    public class CreateOrderContract : Contract<Order>
    {
        public CreateOrderContract(Order Order)
        {
            Requires()
                .IsNotNull(Order.Customer, "Customer", "Cliente inválido")
                .IsNotNullOrEmpty(Order.Number, "Number", "Número do Pedido invalido")
                .IsLowerOrEqualsThan(Order.Items, 0, "Items", "Nenhum pedido inserido.");
        }
    }
}

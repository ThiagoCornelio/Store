using Flunt.Validations;
using Store.Domain.Commands;
using Store.Domain.Entities;

namespace Store.Domain.Command.Contract
{
    public class CreateOrderContract : Contract<Order>
    {
        public CreateOrderContract(CreateOrderCommand order)
        {
            Requires()
                .IsNotNull(order.Customer, "Customer", "Cliente inválido")
                .IsLowerOrEqualsThan(order.Items, 0, "Items", "Nenhum pedido inserido.")
                .AreEquals(order.ZipCode, 8, "ZipCode", "CEP inválido");
        }
    }
}

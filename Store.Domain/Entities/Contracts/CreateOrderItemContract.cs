using Flunt.Validations;

namespace Store.Domain.Entities.Contracts
{
    public class CreateOrderItemContract : Contract<OrderItem>
    {
        public CreateOrderItemContract(OrderItem orderItem)
        {
            Requires()
                .IsNotNull(orderItem.Product, "Product", "Produto Inválido")
                .IsGreaterThan(orderItem.Quantity, 0, "Quantity", "A quantidade deve ser maior que zero");
        }
    }
}

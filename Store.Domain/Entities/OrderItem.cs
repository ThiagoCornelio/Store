using Store.Domain.Entities.Contracts;

namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Price = Product != null ? product.Price : 0;
            Quantity = quantity;

            AddNotifications(new CreateOrderItemContract(this));
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        
        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}

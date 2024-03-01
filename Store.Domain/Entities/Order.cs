using Flunt.Validations;
using Store.Domain.Entities.Contracts;
using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Order : Entity
    {
        public Order(Customer customer, decimal deliveryFee, Discount discount)
        {
            //AddNotifications(
            //    new Contract()
            //        .Requires()
            //        .IsNotNull(customer, "Customer", "Cliente inválido")
            //);
            AddNotifications(new CreateOrderContract(this));

            //Lembrando que o Flunt implementa o DomainNotification
            Customer = customer;
            // Status = EOrderStatus.WaitingPayment;
            DeliveryFee = deliveryFee;
            Discount = discount;
        }

        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public string Number { get; private set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public IList<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public decimal DeliveryFee { get; private set; }
        public Discount Discount { get; private set; }
        public EOrderStatus Status { get; private set; }

        public void AddItem(Product product, int quantity)
        {
            var item = new OrderItem(product, quantity);

            if (item.IsValid)
                Items.Add(item);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFee;
            total -= Discount != null ? Discount.Value() : 0;

            return total;
        }

        public void Pay(decimal amount)
        {
            if (amount == Total())
                this.Status = EOrderStatus.WaitingDelivery;
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }
    }
}
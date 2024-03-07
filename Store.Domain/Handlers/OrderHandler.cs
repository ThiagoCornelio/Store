using Flunt.Notifications;
using Store.Domain.Command;
using Store.Domain.Command.Interfaces;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Utils;
using System.Diagnostics.Contracts;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandler(
            ICustomerRepository customerRepository,
            IDeliveryFeeRepository deliveryFeeRepository,
            IDiscountRepository discountRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeRepository = deliveryFeeRepository;
            _discountRepository = discountRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            // Fail fast validation
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Pedido inválido", null);

            //Recupera os dados do cliente
            var customer = _customerRepository.Get(command.Customer);

            //Calcula a taxa de entrega
            var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

            //Obtem o cupom de desconto
            var discount = _discountRepository.Get(command.PromoCode);

            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
            var order = new Order(customer, deliveryFee, discount);

            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id.Equals(item.Product)).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            //Agrupa as notificações
            AddNotifications(customer, discount, order);

            if (Notifications.Any())
                return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);

            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso.", order);
        }

    }
}

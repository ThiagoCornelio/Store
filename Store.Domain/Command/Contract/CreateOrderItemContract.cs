using Flunt.Validations;
using Store.Domain.Commands;
using Store.Domain.Entities;
using System.Reflection.Emit;

namespace Store.Domain.Command.Contract
{
    public class CreateOrderItemContract : Contract<CreateOrderItemCommand>
    {
        public CreateOrderItemContract(CreateOrderContract orderItem)
        {
            Requires()
            .HasLen(orderItem.Customer, 11, "Customer", "Cliente inválido");
                .HasLen(orderItem.ZipCode, 8, "ZipCode", "CEP inválido")
        }
    }
}

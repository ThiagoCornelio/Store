using Flunt.Validations;

namespace Store.Domain.Entities.Contracts
{
    public class CreateDiscountContract : Contract<Discount>
    {
        public CreateDiscountContract(Discount discount)
        {
            Requires()
                .IsGreaterThan(discount.ExpireDate, DateTime.Now, "Discount.ExpireDate", "Desconto expirado");
        }
    }
}

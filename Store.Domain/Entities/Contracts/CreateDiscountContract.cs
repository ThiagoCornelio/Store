using Flunt.Validations;

namespace Store.Domain.Entities.Contracts
{
    public class CreateDiscountContract : Contract<Discount>
    {
        public CreateDiscountContract(Discount discount)
        {
            Requires()
                .

                 //public bool IsValid()
                 //{
                 //    return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
                 //}
        }
    }
}

using Store.Domain.Entities.Contracts;

namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal amount, DateTime expireDate)
        {
            Amount = amount;
            ExpireDate = expireDate;

            AddNotifications(new CreateDiscountContract(this));
        }

        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set; }
       
        public decimal Value()
        {
            if (IsValid)
                return Amount;
                
            return 0;
        }
    }
}
using Flunt.Validations;

namespace Store.Domain.Entities.Contracts
{
    public class CreateProductContract : Contract<Product>
    {
        public CreateProductContract(Product product)
        {
            Requires()
                .IsNotNullOrEmpty(product.Title, "Title", "Custom error message");
        }
    }
}

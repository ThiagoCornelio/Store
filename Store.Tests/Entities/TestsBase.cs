using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    public abstract class TestsBase
    {
        protected readonly Customer _customer = new Customer("Thiago Cornélio", "thiago@teste.com");
        protected readonly Product _product = new Product("Produto 1", 10, true);
        protected readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));
    }
}

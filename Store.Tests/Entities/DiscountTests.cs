using Store.Domain.Entities;

namespace Store.Tests.Entities
{
    [TestClass]
    public class DiscountTests : TestsBase
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5)); //O desconto vai ser de 0, senão for valido irá retornar 0 apenas
            var order = new Order(_customer, 10, expiredDiscount); //o custo do envio será de 10 - 0(Desconto)
            order.AddItem(_product, 5); //Produto custa 10(variavel) e são 5 quantidades.
            Assert.AreEqual(order.Total(), 60); //Somando o custo do envio 10 + 50(Preço)  =60 
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, null);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }
    }
}

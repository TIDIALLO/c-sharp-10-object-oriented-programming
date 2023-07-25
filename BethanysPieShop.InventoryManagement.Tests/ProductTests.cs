using BethanysPieShop.InventoryManagement.Domain.General;
using BethanysPieShop.InventoryManagement.Domain.ProductManagement;
using Xunit;

namespace BethanysPieShop.InventoryManagement.Tests
{
    public class ProductTests
    {
        [Fact]
        public void UseProduct_Reduce_AmountInStock()
        {
            //Arrange
            Product product = new Product(1, "sugar", "Lorem ipsup", new Price()
            { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            product.IncreaseStock();

            //Act
            product.UseProduct(20);

            //Assert
            Assert.Equal(80, product.AmountInStock);
        }

        [Fact]
        public void UseProduct_Reduce_AmountInStock_StockBelowThereshold()
        {
            //Arrange
            Product product = new Product(1, "sugar", "Lorem ipsup", new Price()
            { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            product.IncreaseStock();

            //Act
            product.UseProduct(0);

            //Assert
            Assert.Equal(0, product.AmountInStock);
        }

    }
}
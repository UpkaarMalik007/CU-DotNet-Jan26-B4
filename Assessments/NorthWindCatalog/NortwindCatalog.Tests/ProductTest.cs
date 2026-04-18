using NorthwindCatalog.Services.DTOs;

namespace NortwindCatalog.Tests
{
    public class ProductTest
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            // Arrange
            var product = new ProductDto
            {
                UnitPrice = 50,
                UnitsInStock = 10
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(500, result);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_Stock_Is_Zero()
        {
            var product = new ProductDto
            {
                UnitPrice = 100,
                UnitsInStock = 0
            };

            var result = product.InventoryValue;

            Assert.Equal(0, result);
        }

        [Fact]
        public void InventoryValue_Should_Handle_Decimals()
        {
            var product = new ProductDto
            {
                UnitPrice = 12.5m,
                UnitsInStock = 4
            };

            var result = product.InventoryValue;

            Assert.Equal(50m, result);
        }
    }
}
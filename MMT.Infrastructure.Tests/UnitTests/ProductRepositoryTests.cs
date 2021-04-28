using MMT.Domain.Products;
using MMT.Infrastructure.EF;
using MMT.Infrastructure.EF.Repositories;
using NUnit.Framework;
using System.Linq;

namespace MMT.Infrastructure.Tests.UnitTests
{
	public class ProductRepositoryTests : TestBase
	{
		[SetUp]
		public void Setup()
		{
			SeedDb();
		}

		[Test]
		public void AddProduct_Success()
		{
			using (var context = new MMTContext(this.dbContextOptions))
			{
				// Arrange
				var productRep = new ProductRepository(context);
				var product = new Product(10000, "Test", "Test", 100, true);

				// Act
				var result = productRep.AddProduct(product);

				// Assert
				Assert.AreEqual(product.Id, result.Id);
			}
		}


		[Test]
		public void GetProductsInSKURange_Success()
		{
			using (var context = new MMTContext(this.dbContextOptions))
			{
				// Arrange
				var productRep = new ProductRepository(context);
				var skuStart = 10000;
				var skuEnd = 30000;
				var expectedProducts = FakeProducts().Where(a => a.SKU >= skuStart && a.SKU < skuEnd);

				// Act
				var result = productRep.GetProductsInSKURange(10000, 30000);

				// Assert
				Assert.AreEqual(expectedProducts.Count(), result.Count());
				foreach (var item in expectedProducts)
				{
					Assert.IsTrue(result.Any(a => a.Name == item.Name && a.SKU== item.SKU && a.Price == item.Price && a.IsFeatured == item.IsFeatured));
				}
			}
		}
	}
}

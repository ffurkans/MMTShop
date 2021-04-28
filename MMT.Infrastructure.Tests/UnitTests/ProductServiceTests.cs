using MMT.Domain.Abstractions;
using MMT.Domain.Categories;
using MMT.Domain.Products;
using MMT.Infrastructure.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MMT.Infrastructure.Tests.UnitTests
{
	public class ProductServiceTests: TestBase
	{
		private Mock<IProductRepository> _productRepositoryMock;
		private Mock<ICategoryRepository> _categoryRepositoryMock;
		private Mock<IUnitOfWork> _unitOfWork;

		[SetUp]
		public void Setup()
		{
			_productRepositoryMock = new Mock<IProductRepository>();
			_categoryRepositoryMock = new Mock<ICategoryRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_unitOfWork.Setup(a => a.SaveChangesAsync(It.IsAny<CancellationToken>()));
			_productRepositoryMock.Setup(a => a.UnitOfWork).Returns(() => _unitOfWork.Object);
		}

		[Test]
		public void GetFeaturedProducts_Success()
		{
			// Arrange
			var fakeCategoriesCanBeFeatured = FakeCategories().Where(a => a.CanBeFeatured);
			var fakeProductsFeatured = FakeProducts().Where(a => a.IsFeatured);
			_categoryRepositoryMock.Setup(a => a.GetCanBeFeaturedCategories()).Returns(fakeCategoriesCanBeFeatured);
			_productRepositoryMock.Setup(a => a.GetFeaturedProductsInSKURange(It.IsAny<Dictionary<int, int>>())).Returns(fakeProductsFeatured);
			var productService = new ProductService(_productRepositoryMock.Object, _categoryRepositoryMock.Object);
			
			// Act
			var products = productService.GetFeaturedProducts();

			//Assert
			foreach (var item in fakeProductsFeatured)
			{
				Assert.IsTrue(products.Any(a => a.Name == item.Name && a.SKU == item.SKU));
			}
		}

		[Test]
		public void GetProductsByCategory_Success()
		{
			// Arrange
			var fakeCategory = FakeCategories().First();
			var fakeProducts = FakeProducts().Where(a => a.SKU >= fakeCategory.SKUStart && a.SKU < fakeCategory.SKUEnd);
			_categoryRepositoryMock.Setup(a => a.GetCategory(fakeCategory.Id)).Returns(fakeCategory);
			_productRepositoryMock.Setup(a => a.GetProductsInSKURange(fakeCategory.SKUStart, fakeCategory.SKUEnd)).Returns(fakeProducts);
			var productService = new ProductService(_productRepositoryMock.Object, _categoryRepositoryMock.Object);

			// Act
			var products = productService.GetProductsByCategory(fakeCategory.Id);

			// Assert
			foreach (var item in fakeProducts)
			{
				Assert.IsTrue(item.SKU >= fakeCategory.SKUStart);
				Assert.IsTrue(item.SKU < fakeCategory.SKUEnd);
			}
		}




	}
}

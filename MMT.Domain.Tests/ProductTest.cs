using MMT.Domain.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.Domain.Tests
{
	class ProductTest
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(10000, "Product 1", "Product 1 Description", 1000, true)]
		[TestCase(20000, "Product 2", "Product 2 Description", 2000, false)]
		public void New_Product_Creation_Success(int sku, string name, string description, decimal price, bool isFeatured)
		{
			// Arrange & Act
			var product = new Product(sku, name, description, price, isFeatured);

			// Assert
			Assert.AreEqual(sku, product.SKU);
			Assert.AreEqual(name, product.Name);
			Assert.AreEqual(description, product.Description);
			Assert.AreEqual(price, product.Price);
			Assert.AreEqual(isFeatured, product.IsFeatured);
		}

		[Test]
		[TestCase(0, "Product 1", "Product 1 Description", 1000, true, "SKU must be greater than 0.")]
		[TestCase(-100, "Product 1", "Product 1 Description", 1000, true, "SKU must be greater than 0.")]
		[TestCase(20000, "Product 4", "Product 4 Description", 0, false, "Price must be greater than 0.")]
		[TestCase(20000, "Product 4", "Product 4 Description", -10, false, "Price must be greater than 0.")]
		public void New_Product_Creation_Fail(int sku, string name, string description, decimal price, bool isFeatured, string message)
		{
			// Arrange & Act
			TestDelegate newProductDelegate = () => new Product(sku, name, description, price, isFeatured);

			// Assert
			Assert.Throws<MMTException>(newProductDelegate, message);
		}


		[Test]
		[TestCase(20000, "", "Product 2 Description", 2000, false)]
		[TestCase(20000, "Product 3", "", 2000, false)]
		public void New_Product_Creation_Fail_ArgumentNullException(int sku, string name, string description, decimal price, bool isFeatured)
		{
			// Arrange & Act
			TestDelegate newProductDelegate = () => new Product(sku, name, description, price, isFeatured);

			// Assert
			Assert.Throws<MMTArgumentNullException>(newProductDelegate);
		}
	}
}

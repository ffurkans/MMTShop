using MMT.Domain.Categories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.Domain.Tests
{
	public class CategoryTest
	{
		[SetUp]
		public void Setup()
		{

		}


		[Test]
		[TestCase("Category 1", 10000, 20000, true)]
		[TestCase("Category 1", 20000, 30000, false)]
		public void Category_Creation_Success(string name, int skuStart, int skuEnd, bool canBeFeatured)
		{
			// Arrange and Act
			var category = new Category(name, skuStart, skuEnd, canBeFeatured);

			// Assert
			Assert.AreEqual(name, category.Name);
			Assert.AreEqual(skuStart, category.SKUStart);
			Assert.AreEqual(skuEnd, category.SKUEnd);
			Assert.AreEqual(canBeFeatured, category.CanBeFeatured);
		}


		[Test]
		[TestCase("Category 1", 0, 20000)]
		[TestCase("Category 1", -100, 20000)]
		[TestCase("Category 1", 30000, 30000)]
		[TestCase("Category 1", 30000, 20000)]
		public void Category_Creation_Fail(string name, int skuStart, int skuEnd)
		{
			// Arrange & Act
			TestDelegate newProductDelegate = () => new Category(name, skuStart, skuEnd, true);

			// Assert
			Assert.Throws<MMTException>(newProductDelegate);
		}


		[Test]
		[TestCase("", 0, 20000)]
		[TestCase("  ", 0, 20000)]
		public void Category_Creation_Fail_ArgumentNullException(string name, int skuStart, int skuEnd)
		{
			// Arrange & Act
			TestDelegate newProductDelegate = () => new Category(name, skuStart, skuEnd, true);

			// Assert
			Assert.Throws<MMTArgumentNullException>(newProductDelegate);
		}

	}
}

using Microsoft.EntityFrameworkCore.Internal;
using MMT.Domain.Categories;
using MMT.Infrastructure.EF;
using MMT.Infrastructure.EF.Repositories;
using NUnit.Framework;
using System.Linq;

namespace MMT.Infrastructure.Tests.UnitTests
{
	public class CategoryRepositoryTests:TestBase
	{
		[SetUp]
		public void Setup()
		{
			SeedDb();
		}

		[Test]
		public void AddCategory_Success()
		{
			using (var context = new MMTContext(this.dbContextOptions))
			{
				// Arrange
				var categoryRep = new CategoryRepository(context);
				var category = new Category("Test", 60000, 70000, true);

				// Act
				var result = categoryRep.AddCategory(category);

				// Assert
				Assert.AreEqual(category.Id, result.Id);
			}
		}

		[Test]
		public void GetAllCategories_Success()
		{
			using (var context = new MMTContext(this.dbContextOptions))
			{
				// Arrange
				var categoryRep = new CategoryRepository(context);
				var expected = FakeCategories();

				// Act
				var result = categoryRep.GetAllCategories();

				// Assert
				foreach (var item in expected)
				{
					Assert.IsTrue(result.Any(a=> a.Name == item.Name && a.SKUStart == item.SKUStart && a.SKUEnd == item.SKUEnd && a.CanBeFeatured == item.CanBeFeatured));
				}
			}
		}

		[Test]
		public void GetCanBeFeaturedCategories_Success()
		{
			using (var context = new MMTContext(this.dbContextOptions))
			{
				// Arrange
				var categoryRep = new CategoryRepository(context);
				var expected = FakeCategories().Where(a=> a.CanBeFeatured);

				// Act
				var result = categoryRep.GetCanBeFeaturedCategories();

				// Assert
				foreach (var item in expected)
				{
					Assert.IsTrue(result.Any(a => a.Name == item.Name && a.SKUStart == item.SKUStart && a.SKUEnd == item.SKUEnd && a.CanBeFeatured == item.CanBeFeatured));
				}
			}
		}


		[Test]
		[TestCase(5000, 15000)]
		[TestCase(60000, 70000)]
		public void GetCategories_Success(int skuStart, int skuEnd)
		{
			using (var context = new MMTContext(this.dbContextOptions))
			{
				// Arrange
				var categoryRep = new CategoryRepository(context);
				var expected = FakeCategories().Where(category => category.SKUStart <= skuEnd && category.SKUEnd >= skuStart);

				// Act
				var result = categoryRep.GetCategories(new CategorySKURangeOverlapSpec(skuStart, skuEnd));

				// Assert
				foreach (var item in expected)
				{
					Assert.IsTrue(result.Any(a => a.Name == item.Name && a.SKUStart == item.SKUStart && a.SKUEnd == item.SKUEnd && a.CanBeFeatured == item.CanBeFeatured));
				}
			}
		}
	}
}

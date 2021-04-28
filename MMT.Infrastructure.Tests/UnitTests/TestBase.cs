using Microsoft.EntityFrameworkCore;
using MMT.Domain.Categories;
using MMT.Domain.Products;
using MMT.Infrastructure.EF;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Infrastructure.Tests.UnitTests
{
	public class TestBase
	{
		protected DbContextOptions<MMTContext> dbContextOptions = new DbContextOptionsBuilder<MMTContext>()
		.UseInMemoryDatabase(databaseName: "MMTShop")
		.Options;

		protected List<Category> FakeCategories()
		{
			return new List<Category>()
			{
				new Category("Home", 10000, 20000, true),
				new Category("Garden", 20000, 30000, true),
				new Category("Electronics", 30000, 40000, true),
				new Category("Fitness", 40000, 50000, false),
				new Category("Toys", 50000, 60000, false)
			};
		}

		protected List<Product> FakeProducts()
		{
			return new List<Product>()
			{
				new Product(10000, "Product 1", "Product Description 1", 100, true),
				new Product(10001, "Product 2", "Product Description 2", 200, false),
				new Product(20000, "Product 3", "Product Description 3", 300, true),
				new Product(30000, "Product 4", "Product Description 4", 400, true),
				new Product(40000, "Product 5", "Product Description 5", 500, true),
				new Product(50000, "Product 6", "Product Description 6", 600, false)
			};
		}


        protected void SeedDb()
        {
			using (var context = new MMTContext(dbContextOptions))
			{
				if (!context.Category.Any())
				{
					context.Category.AddRange(FakeCategories());
				}
				if (!context.Product.Any())
				{
					context.Product.AddRange(FakeProducts());
				}
				context.SaveChanges();
			}
        }
    }
}

using Microsoft.EntityFrameworkCore.Internal;
using MMT.Domain.Categories;
using MMT.Domain.Products;
using System.Linq;

namespace MMT.Infrastructure.EF
{
	public class MMTContextSeed
	{
		public void Seed(MMTContext context)
		{
			if (!context.Category.Any())
			{
				context.Category.Add(new Category("Home", 10000, 20000, true));
				context.Category.Add(new Category("Garden", 20000, 30000,true));
				context.Category.Add(new Category("Electronics", 30000, 40000, true));
				context.Category.Add(new Category("Fitness", 40000, 50000, false));
				context.Category.Add(new Category("Toys", 50000, 60000, false));
			}
			if (!context.Product.Any())
			{
				context.Product.Add(new Product(10000, "Product 1", "Product Description 1", 100, true));
				context.Product.Add(new Product(10001, "Product 2", "Product Description 2", 200, false));
				context.Product.Add(new Product(20000, "Product 3", "Product Description 3", 300, true));
				context.Product.Add(new Product(30000, "Product 4", "Product Description 4", 400, true));
				context.Product.Add(new Product(40000, "Product 5", "Product Description 5", 500, true));
				context.Product.Add(new Product(50000, "Product 6", "Product Description 6", 600, false));
			}
			context.SaveChanges();
		}
	}
}

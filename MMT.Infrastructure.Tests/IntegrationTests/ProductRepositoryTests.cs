using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MMT.Domain.Products;
using MMT.Infrastructure.EF;
using MMT.Infrastructure.EF.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Infrastructure.Tests.IntegrationTests
{
	public class ProductRepositoryTests
	{
		MMTContext _context;

		[SetUp]
		public void Setup()
		{
			var serviceProvider = new ServiceCollection()
			.AddEntityFrameworkSqlServer()
			.BuildServiceProvider();

			var builder = new DbContextOptionsBuilder<MMTContext>();

			builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=MMTShop_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
					.UseInternalServiceProvider(serviceProvider);

			_context = new MMTContext(builder.Options);
			_context.Database.Migrate();
			var seeder = new MMTContextSeed();
			seeder.Seed(_context);
		}


		[Test]
		public void GetFeaturedProductsInSKURange_Success()
		{
			// Arrange
			var productRep = new ProductRepository(_context);
			var skuRanges = _context.Category.Where(a => a.CanBeFeatured).ToDictionary(a => a.SKUStart, b => b.SKUEnd);
			var expectedProducts = new List<Product>();
			foreach (var item in skuRanges)
			{
				expectedProducts.AddRange(_context.Product.Where(a => a.IsFeatured && a.SKU >= item.Key && a.SKU < item.Value));
			}

			// Act
			var result = productRep.GetFeaturedProductsInSKURange(skuRanges);

			// Assert
			Assert.AreEqual(expectedProducts.Count(), result.Count());
			foreach (var item in expectedProducts)
			{
				Assert.IsTrue(result.Any(a => a.Name == item.Name && a.SKU == item.SKU && a.Price == item.Price && a.IsFeatured == item.IsFeatured));
			}
		}


		[TearDown]
		public void TearDown()
		{
			_context.Database.EnsureDeleted();
		}
	}
}

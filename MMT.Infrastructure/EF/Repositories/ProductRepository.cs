using Microsoft.EntityFrameworkCore;
using MMT.Domain;
using MMT.Domain.Abstractions;
using MMT.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMT.Infrastructure.EF.Repositories
{
	/// <summary>
	/// The product repository
	/// </summary>
	public class ProductRepository : IProductRepository
	{
		private readonly MMTContext _context;

		/// <summary>
		/// The unit of work
		/// </summary>
		public IUnitOfWork UnitOfWork
		{
			get
			{
				return _context;
			}
		}

		/// <summary>
		/// Initializes the Product Repository <see cref="ProductRepository"/>
		/// </summary>
		/// <param name="context"></param>
		public ProductRepository(MMTContext context)
		{
			_context = context ?? throw new MMTArgumentNullException(nameof(context));
		}

		/// <summary>
		/// Adds new product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public Product AddProduct(Product product)
		{
			return _context.Product.Add(product).Entity;
		}

		/// <summary>
		/// Deletes the product
		/// </summary>
		/// <param name="product"></param>
		public void DeleteProduct(Product product)
		{
			_context.Product.Remove(product);
		}

		/// <summary>
		/// Gets the products in SKU range
		/// </summary>
		/// <param name="skuStart"></param>
		/// <param name="endSKU"></param>
		/// <returns></returns>
		public IEnumerable<Product> GetProductsInSKURange(int skuStart, int endSKU)
		{
			return _context.Product.Where(a => a.SKU >= skuStart && a.SKU < endSKU);
		}

		/// <summary>
		/// Gets the featured products in SKU range
		/// </summary>
		/// <param name="skuRanges"></param>
		/// <returns></returns>
		public IEnumerable<Product> GetFeaturedProductsInSKURange(Dictionary<int, int> skuRanges)
		{
			StringBuilder query = new StringBuilder( $"SELECT * FROM {nameof(Product)} WHERE IsFeatured = 1");
			if (skuRanges!= null && skuRanges.Count > 0)
			{
				StringBuilder criteria = new StringBuilder();
				foreach (var item in skuRanges)
				{
					criteria.Append("OR").Append($" (SKU >= {item.Key} AND SKU < {item.Value} )");
				}
				criteria.Remove(0, 2);
				query.Append($" AND ({criteria})");
			}
			return _context.Product.FromSqlRaw(query.ToString());
		}


		/// <summary>
		/// Updates the product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public Product UpdateProduct(Product product)
		{
			return _context.Product.Update(product).Entity;
		}

		/// <summary>
		/// Gets the product
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Product GetProduct(Guid IdProduct)
		{
			return _context.Product.Find(IdProduct);
		}
	}
}

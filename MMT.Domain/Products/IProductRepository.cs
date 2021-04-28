using MMT.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace MMT.Domain.Products
{
	/// <summary>
	/// The product repository interface
	/// </summary>
	public interface IProductRepository : IRepository<Product>
	{
		/// <summary>
		/// Adds new product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		Product AddProduct(Product product);
		/// <summary>
		/// Updates the product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		Product UpdateProduct(Product product);
		/// <summary>
		/// Deletes the product
		/// </summary>
		/// <param name="product"></param>
		void DeleteProduct(Product product);
		/// <summary>
		/// Gets the products in SKU range
		/// </summary>
		/// <param name="skuStart"></param>
		/// <param name="endSKU"></param>
		/// <returns></returns>
		IEnumerable<Product> GetProductsInSKURange(int skuStart, int endSKU);
		/// <summary>
		/// Gets the featured products in SKU range
		/// </summary>
		/// <param name="skuRanges"></param>
		/// <returns></returns>
		IEnumerable<Product> GetFeaturedProductsInSKURange(Dictionary<int, int> skuRanges);
		/// <summary>
		/// Gets the product
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		Product GetProduct(Guid IdProduct);
	}
}

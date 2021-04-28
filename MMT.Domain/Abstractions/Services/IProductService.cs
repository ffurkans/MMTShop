using MMT.Domain.Abstractions.DTO;
using System;
using System.Collections.Generic;

namespace MMT.Domain.Abstractions.Services
{
	/// <summary>
	/// The Product Service interface
	/// </summary>
	public interface IProductService
	{
		/// <summary>
		/// Adds new product
		/// </summary>
		/// <param name="product">The product to add</param>
		/// <returns>Saved product</returns>
		ProductDTO AddProduct(ProductDTO product);
		/// <summary>
		/// Updates the product
		/// </summary>
		/// <param name="product">The product to be updated</param>
		/// <returns>Updated product</returns>
		ProductDTO UpdateProduct(ProductDTO product);
		/// <summary>
		/// Updates IsFeatured property of the product
		/// </summary>
		/// <param name="idProduct">The product id</param>
		/// <param name="isFeatured">IsFeatured value to be updated</param>
		/// <returns>Updated product</returns>
		ProductDTO UpdateProductIsFeatured(Guid IdProduct, bool isFeatured);
		/// <summary>
		/// Gets products by category
		/// </summary>
		/// <param name="IdCategory">The category id</param>
		/// <returns>Products filtered by category id</returns>
		IEnumerable<ProductDTO> GetProductsByCategory(Guid IdCategory);
		/// <summary>
		/// Gets featured products
		/// </summary>
		/// <returns>Featured products</returns>
		IEnumerable<ProductDTO> GetFeaturedProducts();
	}
}

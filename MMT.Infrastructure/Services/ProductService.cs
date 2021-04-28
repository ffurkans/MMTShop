using MMT.Domain.Abstractions.DTO;
using MMT.Domain.Abstractions.Services;
using MMT.Domain.Categories;
using MMT.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Infrastructure.Services
{
	/// <summary>
	/// The Product Service
	/// </summary>
	public class ProductService : IProductService
	{
		private readonly IProductRepository productRepository;
		private readonly ICategoryRepository categoryRepository;

		/// <summary>
		/// Initializes the Product Service <see cref="ProductService"/>
		/// </summary>
		/// <param name="productRepository">The product repository</param>
		/// <param name="categoryRepository">The category repository</param>
		public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			this.productRepository = productRepository;
			this.categoryRepository = categoryRepository;
		}

		/// <summary>
		/// Adds new product
		/// </summary>
		/// <param name="product">The product to add</param>
		/// <returns>Saved product</returns>
		public ProductDTO AddProduct(ProductDTO product)
		{
			var newProduct = new Product(product.SKU, product.Name, product.Description, product.Price, product.IsFeatured);
			var result = ToProductDTO(productRepository.AddProduct(newProduct));
			productRepository.UnitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
			return result;
		}

		/// <summary>
		/// Gets products by category
		/// </summary>
		/// <param name="IdCategory">The category id</param>
		/// <returns>Products filtered by category id</returns>
		public IEnumerable<ProductDTO> GetProductsByCategory(Guid IdCategory)
		{
			var category = categoryRepository.GetCategory(IdCategory);
			return productRepository.GetProductsInSKURange(category.SKUStart, category.SKUEnd).Select(a => ToProductDTO(a));
		}

		/// <summary>
		/// Gets featured products
		/// </summary>
		/// <returns>Featured products</returns>
		public IEnumerable<ProductDTO> GetFeaturedProducts()
		{
			var canBeFeaturedCategories = categoryRepository.GetCanBeFeaturedCategories();
			var skuRanges = canBeFeaturedCategories.ToDictionary(a => a.SKUStart, b => b.SKUEnd);
			var featuredProducts = productRepository.GetFeaturedProductsInSKURange(skuRanges);
			return featuredProducts.Select(a=> ToProductDTO(a));
		}

		/// <summary>
		/// Updates the product
		/// </summary>
		/// <param name="product">The product to be updated</param>
		/// <returns>Updated product</returns>
		public ProductDTO UpdateProduct(ProductDTO product)
		{
			var existingProduct = productRepository.GetProduct(product.Id);
			existingProduct.UpdateDetails(product.Name, product.Description);
			existingProduct.UpdatePrice(product.Price);
			existingProduct.UpdateSKU(product.SKU);
			existingProduct.UpdateIsFeatured(product.IsFeatured);
			var result = ToProductDTO(productRepository.UpdateProduct(existingProduct));
			productRepository.UnitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
			return result;
		}

		/// <summary>
		/// Updates IsFeatured property of the product
		/// </summary>
		/// <param name="idProduct">The product id</param>
		/// <param name="isFeatured">IsFeatured value to be updated</param>
		/// <returns>Updated product</returns>
		public ProductDTO UpdateProductIsFeatured(Guid idProduct, bool isFeatured)
		{
			var existingProduct = productRepository.GetProduct(idProduct);
			existingProduct.UpdateIsFeatured(isFeatured);
			var result = ToProductDTO(productRepository.UpdateProduct(existingProduct));
			productRepository.UnitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
			return result;
		}

		/// <summary>
		/// Maps product to ProductDTO
		/// </summary>
		/// <param name="product">The product to be mapped to ProductDTO</param>
		/// <returns>Mapped ProductDTO</returns>
		ProductDTO ToProductDTO(Product product)
		{
			return new ProductDTO()
			{
				Id = product.Id,
				SKU = product.SKU,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				CreateDate = product.CreateDate,
				ModifyDate = product.ModifyDate,
				IsFeatured = product.IsFeatured
			};
		}
	}
}

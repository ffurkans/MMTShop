using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMT.Domain.Abstractions.DTO;
using MMT.Domain.Abstractions.Services;
using System;
using System.Collections.Generic;

namespace MMT.Web.API.Controllers
{
	/// <summary>
	/// The Product controller
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly ILogger<ProductController> logger;
		private readonly IProductService productService;

		/// <summary>
		/// Initializes the Product Controller
		/// </summary>
		/// <param name="logger">The logger</param>
		/// <param name="productService">The product service</param>
		public ProductController(ILogger<ProductController> logger, IProductService productService)
		{
			this.logger = logger;
			this.productService = productService;
		}


		/// <summary>
		/// Gets featured products
		/// </summary>
		/// <returns>Featured product list</returns>
		[HttpGet]
		[Route("products/featured")]
		public IEnumerable<ProductDTO> GetFeaturedProducts()
		{
			return productService.GetFeaturedProducts();
		}

		/// <summary>
		/// Gets products by category id
		/// </summary>
		/// <param name="idCategory">The category id</param>
		/// <returns>Products filtered by category id</returns>
		[HttpGet]
		[Route("products-by-category/{idCategory}")]
		public IEnumerable<ProductDTO> GetProductsByCategory(Guid idCategory)
		{
			return productService.GetProductsByCategory(idCategory);
		}


		/// <summary>
		/// Adds new product
		/// </summary>
		/// <param name="product">The product to add</param>
		/// <returns>Saved product</returns>
		[HttpPost]
		public ProductDTO AddNewProduct(ProductDTO product)
		{
			return productService.AddProduct(product);
		}


		/// <summary>
		/// Updates the product
		/// </summary>
		/// <param name="product">The product to be updated</param>
		/// <returns>The updated product</returns>
		[HttpPut]
		public ProductDTO UpdateProduct(ProductDTO product)
		{
			return productService.UpdateProduct(product);
		}
	}
}

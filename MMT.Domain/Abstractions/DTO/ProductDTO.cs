using System;

namespace MMT.Domain.Abstractions.DTO
{
	/// <summary>
	/// Product Data Transfer Object
	/// </summary>
	public class ProductDTO
	{
		/// <summary>
		/// The Id of the product
		/// </summary>
		public Guid Id { get;  set; }
		/// <summary>
		/// The SKU of the product
		/// </summary>
		public int SKU { get;  set; }
		/// <summary>
		/// The Name of the product
		/// </summary>
		public string Name { get;  set; }
		/// <summary>
		/// The Description of the product
		/// </summary>
		public string Description { get;  set; }
		/// <summary>
		/// The Price of the product
		/// </summary>
		public decimal Price { get;  set; }
		/// <summary>
		/// Flag to define if the product is featured
		/// </summary>
		public bool IsFeatured { get; set; }
		/// <summary>
		/// Create date of the product
		/// </summary>
		public DateTime CreateDate { get; set; }
		/// <summary>
		/// Modify date of the product
		/// </summary>
		public DateTime ModifyDate { get; set; }
	}
}

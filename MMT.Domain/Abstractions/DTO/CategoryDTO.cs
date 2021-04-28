using System;

namespace MMT.Domain.Abstractions.DTO
{
	/// <summary>
	/// Category Data Transfer Object
	/// </summary>
	public class CategoryDTO
	{
		/// <summary>
		/// The Id of the category
		/// </summary>
		public Guid Id { get; set; }
		/// <summary>
		/// The name of the category
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// The SKU Start of the category
		/// </summary>
		public int SKUStart { get; set; }
		/// <summary>
		/// The SKU end of the category
		/// </summary>
		public int SKUEnd { get; set; }
		/// <summary>
		/// Flag that defines if the products in this category can be featured
		/// </summary>
		public bool CanBeFeatured { get; set; }
	}
}

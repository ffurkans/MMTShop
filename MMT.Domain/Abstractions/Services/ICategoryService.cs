using MMT.Domain.Abstractions.DTO;
using System;
using System.Collections.Generic;

namespace MMT.Domain.Abstractions.Services
{
	/// <summary>
	/// The Category Service interface
	/// </summary>
	public interface ICategoryService
	{
		/// <summary>
		/// Adds new category
		/// </summary>
		/// <param name="category">The category to be added</param>
		/// <returns>Added category</returns>
		CategoryDTO AddCategory(CategoryDTO category);
		/// <summary>
		/// Updates the category
		/// </summary>
		/// <param name="category">The category to be updated</param>
		/// <returns>Updated category</returns>
		CategoryDTO UpdateCategory(CategoryDTO category);
		/// <summary>
		/// Updates CanBeFeatured property of the category
		/// </summary>
		/// <param name="idCategory">The category to be updated</param>
		/// <param name="canBeFeatured">The value of the canBeFeatured to be updated</param>
		/// <returns>Updated category</returns>
		CategoryDTO UpdateCategoryCanBeFeatured(Guid IdCategory, bool canBeFeatured);
		/// <summary>
		/// Gets all categories
		/// </summary>
		/// <returns>All categories</returns>
		IEnumerable<CategoryDTO> GetAllCategories();
	}
}

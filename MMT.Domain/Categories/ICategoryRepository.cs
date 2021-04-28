using MMT.Domain.Abstractions;
using MMT.Domain.Abstractions.Specification;
using System;
using System.Collections.Generic;

namespace MMT.Domain.Categories
{
	/// <summary>
	/// The category repository interface
	/// </summary>
	public interface ICategoryRepository : IRepository<Category>
	{
		/// <summary>
		/// Adds new category
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public Category AddCategory(Category category);
		/// <summary>
		/// Updates the category
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public Category UpdateCategory(Category category);
		/// <summary>
		/// Updates category name
		/// </summary>
		/// <param name="idCategory"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public Category UpdateCategoryName(Guid idCategory, string name);
		/// <summary>
		/// Updates the SKU range
		/// </summary>
		/// <param name="idCategory"></param>
		/// <param name="skuStart"></param>
		/// <param name="skuEnd"></param>
		/// <returns></returns>
		public Category UpdateCategorySKURange(Guid idCategory, int skuStart, int skuEnd);
		/// <summary>
		/// Updates can be featured property of the category
		/// </summary>
		/// <param name="idCategory"></param>
		/// <param name="canBeFeatured"></param>
		/// <returns></returns>
		public Category UpdateCategoryCanBeFeatured(Guid idCategory, bool canBeFeatured);
		/// <summary>
		/// Gets the category
		/// </summary>
		/// <param name="idCategory"></param>
		/// <returns></returns>
		public Category GetCategory(Guid idCategory);
		/// <summary>
		/// Gets all categories
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Category> GetAllCategories();
		/// <summary>
		/// Gets the can be featured categories
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Category> GetCanBeFeaturedCategories();
		/// <summary>
		/// Gets the categories based on the spec
		/// </summary>
		/// <param name="specification"></param>
		/// <returns></returns>
		public IEnumerable<Category> GetCategories(ISpecification<Category> specification);
	}
}

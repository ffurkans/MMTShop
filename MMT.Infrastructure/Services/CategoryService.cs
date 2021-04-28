using MMT.Domain;
using MMT.Domain.Abstractions.DTO;
using MMT.Domain.Abstractions.Services;
using MMT.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Infrastructure.Services
{
	/// <summary>
	/// The Category Service
	/// </summary>
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository categoryRepository;

		/// <summary>
		/// Initiazlizes the Category Service <see cref="CategoryService"/>
		/// </summary>
		/// <param name="categoryRepository">The category repository</param>
		public CategoryService(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}

		/// <summary>
		/// Adds new category
		/// </summary>
		/// <param name="category">The category to be added</param>
		/// <returns>Added category</returns>
		public CategoryDTO AddCategory(CategoryDTO category)
		{
			var newCategory = new Category(category.Name, category.SKUStart, category.SKUEnd, category.CanBeFeatured);
			var overlappedCategories = categoryRepository.GetCategories(new CategorySKURangeOverlapSpec(category.SKUStart, category.SKUEnd));
			if (overlappedCategories.Any())
			{
				throw new MMTException("Overlapped categories");
			}
			var result = ToCategoryDTO(categoryRepository.AddCategory(newCategory));
			categoryRepository.UnitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
			return result;
		}

		/// <summary>
		/// Gets all categories
		/// </summary>
		/// <returns>All categories</returns>
		public IEnumerable<CategoryDTO> GetAllCategories()
		{
			return categoryRepository.GetAllCategories().Select(a => ToCategoryDTO(a));
		}

		/// <summary>
		/// Updates the category
		/// </summary>
		/// <param name="category">The category to be updated</param>
		/// <returns>Updated category</returns>
		public CategoryDTO UpdateCategory(CategoryDTO category)
		{
			var existingCategory = categoryRepository.GetCategory(category.Id);
			existingCategory.UpdateCategoryName(category.Name);
			existingCategory.UpdateSKURange(category.SKUStart, category.SKUEnd);
			existingCategory.UpdateCanBeFeatured(category.CanBeFeatured);
			var result = ToCategoryDTO(categoryRepository.UpdateCategory(existingCategory));
			categoryRepository.UnitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
			return result;
		}

		/// <summary>
		/// Updates CanBeFeatured property of the category
		/// </summary>
		/// <param name="idCategory">The category to be updated</param>
		/// <param name="canBeFeatured">The value of the canBeFeatured to be updated</param>
		/// <returns>Updated category</returns>
		public CategoryDTO UpdateCategoryCanBeFeatured(Guid idCategory, bool canBeFeatured)
		{
			var existingCategory = categoryRepository.GetCategory(idCategory);
			existingCategory.UpdateCanBeFeatured(canBeFeatured);
			var result = ToCategoryDTO(categoryRepository.UpdateCategory(existingCategory));
			categoryRepository.UnitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
			return result;
		}

		/// <summary>
		/// Maps category toCategoryDTO
		/// </summary>
		/// <param name="category">The category</param>
		/// <returns>The mapped CategoryDTO</returns>
		CategoryDTO ToCategoryDTO(Category category)
		{
			return new CategoryDTO()
			{
				Id = category.Id,
				Name = category.Name,
				SKUStart = category.SKUStart,
				SKUEnd = category.SKUEnd,
				CanBeFeatured = category.CanBeFeatured
			};
		}
	}
}

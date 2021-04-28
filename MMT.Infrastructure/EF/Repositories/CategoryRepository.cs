using MMT.Domain;
using MMT.Domain.Abstractions;
using MMT.Domain.Abstractions.Specification;
using MMT.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Infrastructure.EF.Repositories
{
	/// <summary>
	/// The category repository
	/// </summary>
	public class CategoryRepository : ICategoryRepository
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
		/// Initializes the CategoryRepository <see cref="CategoryRepository"/>
		/// </summary>
		/// <param name="context">The db context</param>
		public CategoryRepository(MMTContext context)
		{
			_context = context ?? throw new MMTArgumentNullException(nameof(context));
		}

		/// <summary>
		/// Adds new category
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public Category AddCategory(Category category)
		{
			return _context.Category.Add(category).Entity;
		}

		/// <summary>
		/// Gets all categories
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Category> GetAllCategories()
		{
			return _context.Category;
		}

		/// <summary>
		/// Updates the category
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public Category UpdateCategory(Category category)
		{
			return _context.Category.Update(category).Entity;
		}

		/// <summary>
		/// Updates category name
		/// </summary>
		/// <param name="idCategory"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public Category UpdateCategoryName(Guid idCategory, string name)
		{
			var category = _context.Category.Find(idCategory);
			category.UpdateCategoryName(name);
			return _context.Category.Update(category).Entity;
		}

		/// <summary>
		/// Updates the SKU range
		/// </summary>
		/// <param name="idCategory"></param>
		/// <param name="skuStart"></param>
		/// <param name="skuEnd"></param>
		/// <returns></returns>
		public Category UpdateCategorySKURange(Guid idCategory, int skuStart, int skuEnd)
		{
			var category = _context.Category.Find(idCategory);
			category.UpdateSKURange(skuStart, skuEnd);
			return _context.Category.Update(category).Entity;
		}

		/// <summary>
		/// Updates can be featured property of the category
		/// </summary>
		/// <param name="idCategory"></param>
		/// <param name="canBeFeatured"></param>
		/// <returns></returns>
		public Category UpdateCategoryCanBeFeatured(Guid idCategory, bool canBeFeatured)
		{
			var category = _context.Category.Find(idCategory);
			category.UpdateCanBeFeatured(canBeFeatured);
			return _context.Category.Update(category).Entity;
		}

		/// <summary>
		/// Gets the category
		/// </summary>
		/// <param name="idCategory"></param>
		/// <returns></returns>
		public Category GetCategory(Guid idCategory)
		{
			return _context.Category.Find(idCategory);
		}

		/// <summary>
		/// Gets the can be featured categories
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Category> GetCanBeFeaturedCategories()
		{
			return _context.Category.Where(a => a.CanBeFeatured);
		}

		/// <summary>
		/// Gets the categories based on the spec
		/// </summary>
		/// <param name="specification"></param>
		/// <returns></returns>
		public IEnumerable<Category> GetCategories(ISpecification<Category> specification)
		{
			return _context.Category.Where(specification.SpecExpression);
		}
	}
}

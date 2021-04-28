using MMT.Domain.Abstractions;
using System;

namespace MMT.Domain.Categories
{
	/// <summary>
	/// The Category class that defines category of a product
	/// </summary>
	public class Category : IAggregateRoot
	{
		/// <summary>
		/// The Id of the category
		/// </summary>
		public Guid Id { get; protected set; }
		/// <summary>
		/// The name of the category
		/// </summary>
		public string Name { get; protected set; }
		/// <summary>
		/// The SKU Start of the category
		/// </summary>
		public int SKUStart { get; protected set; }
		/// <summary>
		/// The SKU end of the category
		/// </summary>
		public int SKUEnd { get; protected set; }
		/// <summary>
		/// Flag that defines if the products in this category can be featured
		/// </summary>
		public bool CanBeFeatured { get; protected set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public Category()
		{

		}

		/// <summary>
		/// Initialized the category object <see cref="Category"/>
		/// </summary>
		/// <param name="name">The name of the category</param>
		/// <param name="skuStart">The sku start of the category</param>
		/// <param name="skuEnd">The sku end of the category</param>
		public Category(string name, int skuStart, int skuEnd, bool canBeFeatured)
		{
			Id = Guid.NewGuid();
			UpdateCategoryName(name);
			UpdateSKURange(skuStart, skuEnd);
			UpdateCanBeFeatured(canBeFeatured);
		}

		/// <summary>
		/// Updates the category name
		/// </summary>
		/// <param name="name">The new name</param>
		public void UpdateCategoryName(string name)
		{
			Name = !string.IsNullOrWhiteSpace(name) ? name : throw new MMTArgumentNullException(nameof(name));
		}

		/// <summary>
		/// Updates the category sku range
		/// </summary>
		/// <param name="skuStart">The new sku start</param>
		/// <param name="skuEnd">The new sku end</param>
		public void UpdateSKURange(int skuStart, int skuEnd)
		{
			if (skuStart <= 0)
			{
				throw new MMTException("SKU Start must be greater than 0.");
			}
			if (skuEnd <= 0)
			{
				throw new MMTException("SKU End must be greater than 0.");
			}
			if (skuStart >= skuEnd)
			{
				throw new MMTException("SKU Start must be lower than SKU End.");
			}
			SKUStart = skuStart;
			SKUEnd = skuEnd;
		}

		/// <summary>
		/// Updates the CanBeFeatured property of the Category
		/// </summary>
		/// <param name="canBeFeatured">The flag defines wheter the category can be featured or not</param>
		public void UpdateCanBeFeatured(bool canBeFeatured)
		{
			CanBeFeatured = canBeFeatured;
		}
	}
}

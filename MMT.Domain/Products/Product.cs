using MMT.Domain.Abstractions;
using System;

namespace MMT.Domain.Products
{
	/// <summary>
	/// The Product class that defines properties such as SKU, Name, Price of a product
	/// </summary>
	public class Product: IAggregateRoot
	{
		/// <summary>
		/// The Id of the product
		/// </summary>
		public Guid Id { get; protected set; }
		/// <summary>
		/// The SKU of the product
		/// </summary>
		public int SKU { get; protected set; }
		/// <summary>
		/// The Name of the product
		/// </summary>
		public string Name { get; protected set; }
		/// <summary>
		/// The Description of the product
		/// </summary>
		public string Description { get; protected set; }
		/// <summary>
		/// The Price of the product
		/// </summary>
		public decimal Price { get; protected set; }
		/// <summary>
		/// Flag to define if the product is featured
		/// </summary>
		public bool IsFeatured { get; protected set; }
		/// <summary>
		/// Create date of the product
		/// </summary>
		public DateTime CreateDate { get; protected set; }
		/// <summary>
		/// Modify date of the product
		/// </summary>
		public DateTime ModifyDate { get; protected set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public Product()
		{

		}

		/// <summary>
		/// Initialized the Product class <see cref="Product"/>
		/// </summary>
		/// <param name="sku">The sku of the product</param>
		/// <param name="name">The name of the product</param>
		/// <param name="description">The description of the product</param>
		/// <param name="price">The price of the product</param>
		public Product(int sku, string name, string description, decimal price, bool isFeatured)
		{
			Id = Guid.NewGuid();
			CreateDate = DateTime.UtcNow;
			ModifyDate = DateTime.UtcNow;
			UpdateSKU(sku);
			UpdateDetails(name, description);
			UpdatePrice(price);
			UpdateIsFeatured(isFeatured);
		}

		/// <summary>
		/// Updates name and description of the product
		/// </summary>
		/// <param name="name">The new name of the product</param>
		/// <param name="description">The new description of the product</param>
		public void UpdateDetails(string name, string description)
		{
			Name = !string.IsNullOrWhiteSpace(name) ? name : throw new MMTArgumentNullException(nameof(name));
			Description = !string.IsNullOrWhiteSpace(description) ? description : throw new MMTArgumentNullException(nameof(description));
			ModifyDate = DateTime.UtcNow;
		}


		/// <summary>
		/// Updates the price of the product
		/// </summary>
		/// <param name="price">The new price of the product</param>
		public void UpdatePrice(decimal price)
		{
			if (price <= 0)
			{
				throw new MMTException("Price must be greater than 0.");
			}
			Price = price;
			ModifyDate = DateTime.UtcNow;
		}

		/// <summary>
		/// Updates the sku of the product
		/// </summary>
		/// <param name="sku"></param>
		public void UpdateSKU(int sku)
		{
			if (sku <= 0)
			{
				throw new MMTException("SKU must be greater than 0.");
			}
			SKU = sku;
			ModifyDate = DateTime.UtcNow;
		}

		/// <summary>
		/// Updates the IsFeatured property of the product
		/// </summary>
		/// <param name="isFeatured">Flag to define if produc can be featured or not</param>
		public void UpdateIsFeatured(bool isFeatured)
		{
			IsFeatured = isFeatured;
			ModifyDate = DateTime.UtcNow;
		}
	}
}

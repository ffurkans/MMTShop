using MMT.Domain.Abstractions.Specification;
using System;
using System.Linq.Expressions;

namespace MMT.Domain.Categories
{
	/// <summary>
	/// The specification that checkes wheather the skuStart and skuEnd overlaps the existing category
	/// </summary>
	public class CategorySKURangeOverlapSpec : SpecificationBase<Category>
	{
		private readonly int skuStart;
		private readonly int skuEnd;

		/// <summary>
		/// Initizalizes CategorySKURangeOverlapSpec
		/// </summary>
		/// <param name="skuStart"></param>
		/// <param name="skuEnd"></param>
		public CategorySKURangeOverlapSpec(int skuStart, int skuEnd)
		{
			this.skuStart = skuStart;
			this.skuEnd = skuEnd;
		}

		/// <summary>
		/// Expression to check wheather the skuStart and skuEnd overlaps the existing category
		/// </summary>
		public override Expression<Func<Category, bool>> SpecExpression
		{
			get
			{
				return category => category.SKUStart <= skuEnd && category.SKUEnd >= skuStart;
			}
		}
	}
}

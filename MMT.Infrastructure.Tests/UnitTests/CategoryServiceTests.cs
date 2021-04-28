using MMT.Domain;
using MMT.Domain.Abstractions;
using MMT.Domain.Abstractions.DTO;
using MMT.Domain.Abstractions.Specification;
using MMT.Domain.Categories;
using MMT.Infrastructure.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MMT.Infrastructure.Tests.UnitTests
{
	public class CategoryServiceTests : TestBase
	{
		private Mock<ICategoryRepository> _categoryRepositoryMock;
		private Mock<IUnitOfWork> _unitOfWork;

		[SetUp]
		public void Setup()
		{
			_categoryRepositoryMock = new Mock<ICategoryRepository>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_unitOfWork.Setup(a => a.SaveChangesAsync(It.IsAny<CancellationToken>()));
			_categoryRepositoryMock.Setup(a => a.UnitOfWork).Returns(() => _unitOfWork.Object);
		}

		[Test]
		public void AddCategory_Success()
		{
			// Arrange
			var categoryService = new CategoryService(_categoryRepositoryMock.Object);
			var categoryDTO = new CategoryDTO()
			{
				Name = "Category 1",
				CanBeFeatured = true,
				SKUStart = 10000,
				SKUEnd = 20000
			};
			var fakeCategory = new Category(categoryDTO.Name, categoryDTO.SKUStart, categoryDTO.SKUEnd, categoryDTO.CanBeFeatured);
			_categoryRepositoryMock.Setup(a => a.GetCategories(It.IsAny<ISpecification<Category>>()))
				.Returns(new List<Category>());
			_categoryRepositoryMock.Setup(a => a.AddCategory(It.IsAny<Category>()))
				.Returns(fakeCategory);

			// Act
			var result = categoryService.AddCategory(categoryDTO);

			// Assert
			Assert.AreEqual(fakeCategory.Name, result.Name);
			Assert.AreEqual(fakeCategory.SKUStart, result.SKUStart);
			Assert.AreEqual(fakeCategory.SKUEnd, result.SKUEnd);
		}


		[Test]
		public void AddCategory_OverlappedSKU_Fail()
		{
			// Arrange
			var categoryService = new CategoryService(_categoryRepositoryMock.Object);
			var categoryDTO = new CategoryDTO()
			{
				Name = "Category 1",
				CanBeFeatured = true,
				SKUStart = 10000,
				SKUEnd = 20000
			};
			var fakeCategory = new Category(categoryDTO.Name, categoryDTO.SKUStart, categoryDTO.SKUEnd, categoryDTO.CanBeFeatured);
			_categoryRepositoryMock.Setup(a => a.GetCategories(It.IsAny<ISpecification<Category>>()))
				.Returns(FakeCategories());
			_categoryRepositoryMock.Setup(a => a.AddCategory(It.IsAny<Category>()))
				.Returns(fakeCategory);

			// Act
			TestDelegate result = () => categoryService.AddCategory(categoryDTO);

			// Assert
			Assert.Throws<MMTException>(result, "Overlapped categories");
		}


		[Test]
		public void GetAllCategories_Success()
		{
			// Arrange
			var categoryService = new CategoryService(_categoryRepositoryMock.Object);
			var fakeCategories = FakeCategories();
			_categoryRepositoryMock.Setup(a => a.GetAllCategories())
				.Returns(fakeCategories);

			// Act
			var result = categoryService.GetAllCategories();

			// Assert
			foreach (var item in fakeCategories)
			{
				Assert.IsTrue(result.Any(a => a.Name == item.Name && a.SKUStart == item.SKUStart && a.SKUEnd == item.SKUEnd && a.CanBeFeatured == item.CanBeFeatured));
			}
		}
	}
}

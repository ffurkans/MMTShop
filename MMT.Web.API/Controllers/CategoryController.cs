using Microsoft.AspNetCore.Mvc;
using MMT.Domain.Abstractions.DTO;
using MMT.Domain.Abstractions.Services;
using System.Collections.Generic;

namespace MMT.Web.API.Controllers
{
    /// <summary>
    /// The Category controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Initializes the category controller
        /// </summary>
        /// <param name="categoryService">The category service</param>
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>All categories</returns>
        [HttpGet]
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            return categoryService.GetAllCategories();
        }

        /// <summary>
        /// Adds new category
        /// </summary>
        /// <param name="category">The category to save</param>
        /// <returns>Saved category</returns>
        [HttpPost]
        public CategoryDTO AddCategory([FromBody]CategoryDTO category)
        {
            return categoryService.AddCategory(category);
        }

        /// <summary>
        /// Updates category
        /// </summary>
        /// <returns>The updated category</returns>
        [HttpPut]
        public CategoryDTO UpdateCategory([FromBody]CategoryDTO category)
        {
            return categoryService.UpdateCategory(category);
        }
    }
}
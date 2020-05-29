using BookSubscription.Application.Interfaces;
using BookSubscription.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookSubscription.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<BooksController> logger, 
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        /// <summary>
        /// Get the list of all category
        /// </summary>
        /// <returns>The list of category</returns>
        /// <response code="200">Return the list of category</response>
        /// <response code="404">Not found</response>
        // Get: api/category
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        /// <summary>
        /// Get the category
        /// </summary>
        /// <returns>The category</returns>
        /// <response code="200">Return the category</response>
        /// <response code="404">Not found</response>
        // Get: api/category
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryService.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Category entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _categoryService.UpdateAsync(entity);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category entity)
        {
            await _categoryService.AddAsync(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(Guid id)
        {
            var category = await _categoryService.DeleteAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
    }
}
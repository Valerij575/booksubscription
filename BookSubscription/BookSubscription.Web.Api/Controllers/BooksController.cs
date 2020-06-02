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
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService) 
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Get the list of all books
        /// </summary>
        /// <returns>The list of Weather</returns>
        /// <response code="200">Return the list of books</response>
        /// <response code="404">Not found</response>
        // Get: api/books
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        /// <summary>
        /// Get the book
        /// </summary>
        /// <returns>The book</returns>
        /// <response code="200">Return the book</response>
        /// <response code="404">Not found</response>
        // Get: api/books
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var book = await _bookService.GetAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Book entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _bookService.UpdateAsync(entity);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book entity)
        {
            await _bookService.AddAsync(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(Guid id)
        {
            var book = await _bookService.DeleteAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }
    }
}
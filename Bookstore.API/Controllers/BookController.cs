using Bookstore.Domain.Interfaces.Services;
using Bookstore.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
                return NotFound();

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            var addedBook = await _bookService.AddBookAsync(book);

            return CreatedAtAction(nameof(GetBookById), new { id = addedBook.Id }, addedBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            var updatedBook = await _bookService.UpdateBookAsync(id, book);

            if (updatedBook == null)
                return NotFound();

            return updatedBook;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}

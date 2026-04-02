using Humanizer;
using LibraryAPIManagement.Data;
using LibraryAPIManagement.DTO;
using LibraryAPIManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPIManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(MyAppDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            _logger.LogInformation("GET api/books endpoint hit");
            var books = await _context.Books
            .Include(b => b.Author)
            .Select(b => new
            {
                b.BookId,
                b.Title,
                b.Price,
                AuthorName = b.Author.Name
            })
            .ToListAsync();
            return Ok(books);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBook(int id)
        {
            _logger.LogInformation("Fetching book with ID {BookId}", id);

            var book = await _context.Books
        .Include(b => b.Author)
        .Where(b => b.BookId == id)
        .Select(b => new
        {
            b.BookId,
            b.Title,
            b.Price,
            AuthorName = b.Author.Name
        })
        .FirstOrDefaultAsync();

            if (book == null)
            {
                _logger.LogWarning("Book with ID {BookId} not found", id);
                return NotFound($"Book with ID {id} not found");
            }

            return Ok(book);
        }

        

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(CreateBookDto dto)
        {
            _logger.LogInformation("Adding new book {Title}", dto.Title);

            var book = new Book
            {
                Title = dto.Title,
                Price = dto.Price,
                AuthorId = dto.AuthorId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var result = await _context.Books
                .Include(b => b.Author)
                .Where(b => b.BookId == book.BookId)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Price,
                    b.AuthorId,
                    AuthorName = b.Author.Name
                })
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _logger.LogInformation("Deleting book with ID {BookId}", id);

            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                _logger.LogWarning("Delete failed. Book ID {BookId} not found", id);
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
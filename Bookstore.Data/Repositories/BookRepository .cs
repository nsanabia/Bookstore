using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return _context.Books.ToList();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                // Atualize outros campos conforme necessário
                await _context.SaveChangesAsync();
            }

            return existingBook;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

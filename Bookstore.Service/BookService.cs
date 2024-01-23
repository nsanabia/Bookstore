using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain.Interfaces.Services;
using Bookstore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            return await _bookRepository.AddBookAsync(book);
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            return await _bookRepository.UpdateBookAsync(id, book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }
    }
}

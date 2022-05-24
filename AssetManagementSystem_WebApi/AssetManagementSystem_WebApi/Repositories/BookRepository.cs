using AssetManagementSystem_WebApi.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem_WebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AssetDb _context;
        public BookRepository(AssetDb context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task Delete(int Id)
        {
            var BookToDelete = await _context.Books.FindAsync(Id);
            _context.Books.Remove(BookToDelete);
            await _context.SaveChangesAsync();
        }



        public async Task Search(string name)
        {

            await _context.Books.FindAsync(name);
        }
        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePatchBooksAsync(int Id, JsonPatchDocument book)
        {
            var bookToUpdate = await _context.Books.FindAsync(Id);
            if (bookToUpdate == null)
            {
                book.ApplyTo(bookToUpdate);
                await _context.SaveChangesAsync();
            }

        }

        Task<IEnumerable<Book>> IBookRepository.Search(string name)
        {
            throw new NotImplementedException();
        }

        public Task FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

       

        internal static void ApplyTo(Book? bookToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
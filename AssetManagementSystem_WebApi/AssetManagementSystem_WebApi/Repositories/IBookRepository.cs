using AssetManagementSystem_WebApi.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem_WebApi.Repositories
{
    public interface IBookRepository
    {

        Task<IEnumerable<Book>> Search(string name);
        Task<IEnumerable<Book>> Get();

        Task<Book> Get(int Id);
        Task <Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int Id);

        Task UpdatePatchBooksAsync(int Id,JsonPatchDocument book);
        
      


    }
}

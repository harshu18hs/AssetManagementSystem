using AssetManagementSystem_WebApi.Models;
using AssetManagementSystem_WebApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using HttpPatchAttribute = Microsoft.AspNetCore.Mvc.HttpPatchAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using Microsoft.AspNetCore.Identity;
using System.Security;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace AssetManagementSystem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Book>>> Search(string Name)
        {
            try
            {
                var result = await _bookRepository.Search(Name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            var books = await _bookRepository.Get(id);
            if (books == null)
            {
                return Ok("No Book Available");
            }
            return Ok(books);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("PostBooks")]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<ActionResult<Book>> PutBooks(int Id, [FromBody] Book book)
        {
            if (Id != book.Id)
            {
                return BadRequest();
            }
            await _bookRepository.Update(book);
            return Ok(book);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var BookToDelete = await _bookRepository.Get(Id);
            if (BookToDelete == null)
                return NotFound();
            await _bookRepository.Delete(BookToDelete.Id);
            return NoContent();
        }
    }
}
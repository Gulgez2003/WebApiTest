using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiTest.DAL;
using WebApiTest.Dtos;
using WebApiTest.Dtos.BookDtos;
using WebApiTest.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Books()
        {
            IQueryable<Book> books=_context.Books;
            GetAllDtos<BookGetDto> getAllDtos = new();
            getAllDtos.Items=await books.Select(b=>new BookGetDto { Id=b.Id, Name=b.Name,Price=b.Price }).ToListAsync();
            return StatusCode((int)HttpStatusCode.OK, getAllDtos.Items);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Create(BookPostDto postDto)
        {
            await _context.Books.AddAsync(new Book { Name = postDto.Name, Price=postDto.Price});
            _context.SaveChanges();
            return NoContent();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

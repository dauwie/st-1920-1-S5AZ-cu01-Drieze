using System.IO;
using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerCrudBase<Book, BookRepository>
    {
        IHostingEnvironment _hostingEnvironment;

        public BooksController(BookRepository bookRepository, IHostingEnvironment hostingEnvironment):base(bookRepository)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Books 
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        // GET: api/Books/Basic 
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBooksBasic()
        {
            return Ok(await repository.ListBasic());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            return Ok(await repository.GetById(id));
        }

        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(_hostingEnvironment.WebRootPath, "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        [HttpGet]
        [Route("ImageById/{id}")]
        public async Task<IActionResult> ImageById(int id)
        {
            //var filename = repository.GetById(id).Result.FileName;
            var book  =  await repository.GetById(id);
            
            var image = Path.Combine(_hostingEnvironment.WebRootPath, "images", book.FileName);
            return PhysicalFile(image, "image/jpeg");
        }
    }
}
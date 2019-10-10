using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookRepository repository; IHostingEnvironment _hostingEnvironment;

        public BooksController(BookRepository bookRepository, IHostingEnvironment hostingEnvironment)
        {
            repository = bookRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Books 
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(repository.ListAll());
        }

        // GET: api/Books/Basic 
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBooksBasic()
        {
            return Ok(repository.ListBasic());
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBookDetail(int id)
        {
            return Ok(repository.GetById(id));
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
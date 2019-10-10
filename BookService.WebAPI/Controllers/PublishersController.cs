using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerCrudBase<Publisher, PublisherRepository>
    {
        public PublishersController(PublisherRepository publisherRepository) : base(publisherRepository)
        {
        }
    }
}
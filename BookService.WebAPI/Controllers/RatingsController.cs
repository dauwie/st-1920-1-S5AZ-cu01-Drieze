using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerCrudBase<Rating, RatingRepository>
    {
        public RatingsController(RatingRepository repository) : base(repository)
        {
        }

        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }
    }
}
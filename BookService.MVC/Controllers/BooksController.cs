using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookService.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseUri = "https://localhost:5001/api/books";
        public IActionResult Index()
        {
            string bookUri = $"{baseUri}/basic";

            return View(GetApiResult<List<BookBasic>>(bookUri));
        }

        private T GetApiResult<T>(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(
                    () => JsonConvert.DeserializeObject<T>(response.Result)
                    ).Result;
            }
        }
    }
}
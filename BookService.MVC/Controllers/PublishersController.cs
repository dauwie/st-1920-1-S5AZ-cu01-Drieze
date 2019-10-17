using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BookService.MVC.Controllers
{
    public class PublishersController : Controller
    {
        string baseUri = "https://localhost:5001/api/publishers";
        public IActionResult Index()
        {
            string publisherUri = $"{baseUri}/basic";
            return View(WebApiHelper.GetApiResult<List<PublisherBasic>>(publisherUri));
        }

        public IActionResult Detail(int id)
        {
            string publisherUri = $"{baseUri}/{id}";
            return View(WebApiHelper.GetApiResult<Publisher>(publisherUri));
        }
    }
}
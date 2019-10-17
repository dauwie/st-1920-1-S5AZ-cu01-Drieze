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
        public IActionResult Edit(int id)
        {
            string uri = $"{baseUri}/{id}";
            ViewBag.Mode = "Edit";
            return View("Detail", WebApiHelper.GetApiResult<Publisher>(uri));
        }

        public IActionResult Insert()
        {
            ViewBag.Mode = "Edit";
            return View("Detail", new Publisher());
        }

        [HttpPost]
        public async Task<IActionResult> Save(Publisher publisher)
        {
            if (publisher.Id != 0)
            {
                // update
                string uri = $"{baseUri}/{publisher.Id}";
                publisher = await WebApiHelper.PutCallApi<Publisher, Publisher>(uri, publisher);
            }
            else
            {
                // insert
                string uri = $"{baseUri}";
                publisher = await WebApiHelper.PostCallApi<Publisher, Publisher>(uri, publisher);
            }

            ViewBag.Mode = "Detail";
            return View("Detail", publisher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            string uri = $"{baseUri}/{id}";
            Publisher publisher = await WebApiHelper.DeleteCallApi<Publisher>(uri);
            return RedirectToAction("Index");
        }


    }
}
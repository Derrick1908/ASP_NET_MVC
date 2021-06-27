using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreMVC.ViewModels;

namespace MusicStoreMVC.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            var genres = new List<string> { "Rock", "Jazz", "Country", "Pop", "Disco" };

            var viewModel = new StoreIndexViewModel
            {
                NumberofGenres = genres.Count(),
                Genres = genres
            };

            return View(viewModel);
        }

        // GET: /Store/Browse
        public string Browse(string genre)
        {
            string message = "Store.Browse, Genre = " + Server.HtmlEncode(genre);
            return message;
        }

        // GET: /Store/Details/5
        public string Details(int id)
        {
            string message = "Store.Details, Id = " + id;
            return Server.HtmlEncode(message);
        }
    }
}
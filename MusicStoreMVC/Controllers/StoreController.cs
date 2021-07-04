using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreMVC.ViewModels;
using MusicStoreMVC.Models;

namespace MusicStoreMVC.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            //Create a list of Genres
            var genres = new List<string> { "Rock", "Jazz", "Country", "Pop", "Disco" };

            //Create a View Model
            var viewModel = new StoreIndexViewModel
            {
                NumberofGenres = genres.Count(),
                Genres = genres
            };

            return View(viewModel);
        }

        // GET: /Store/Browse
        public ActionResult Browse()
        {
            string genreName = Server.HtmlEncode(Request.QueryString["genre"]);
            var genre = new Genre {
                Name = genreName
            };
            var albums = new List<Album>();
            albums.Add(new Album { Title = genreName + "Album 1" });
            albums.Add(new Album { Title = genreName + "Album 2" });

            var viewModel = new StoreBrowseViewModel
            {
                Genre = genre,
                Albums = albums
            };

            return View(viewModel);
        }

        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var album = new Album { Title = "Sample Album" };
            return View(album);
        }
    }
}
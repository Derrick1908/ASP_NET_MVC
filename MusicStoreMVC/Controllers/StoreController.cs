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
        MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: Store
        public ActionResult Index()
        {
            //Retrieve list of Genres from Database
            var genres = from genre in storeDB.Genres
                         select genre.Name;

            //Set up our View Model
            var viewModel = new StoreIndexViewModel
            {
                NumberofGenres = genres.Count(),
                Genres = genres.ToList()
            };

            //Return the View
            return View(viewModel);
        }

        // GET: /Store/Browse?Genre=Disco
        public ActionResult Browse(string genre)
        {
            //Retreive Genre from database
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            var viewModel = new StoreBrowseViewModel
            {
                Genre = genreModel,
                Albums = genreModel.Albums.ToList()
            };

            return View(viewModel);
        }

        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.SingleOrDefault(a => a.AlbumId == id);
            
            return View(album);
        }
    }
}
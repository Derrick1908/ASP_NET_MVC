using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreMVC.Models;
using MusicStoreMVC.ViewModels;

namespace MusicStoreMVC.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        
        // GET: /StoreManager/
        public ActionResult Index()
        {
            var albums = storeDB.Albums
                .Include("Genre").Include("Artist")
                .ToList();

            return View(storeDB.Albums);
        }

      
        // GET: /StoreManager/Create
        public ActionResult Create()
        {
            var viewModel = new StoreManagerViewModel
            {
                Album = new Album(),
                Genres = storeDB.Genres.ToList(),
                Artists = storeDB.Artists.ToList()
            };

            return View(viewModel);
        }

        // POST: /StoreManager/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            try
            {
                //Save Album
                storeDB.Albums.Add(album);
                storeDB.SaveChanges();

                return RedirectToAction("/");
            }
            catch
            {
                //Invalid - redisplay with errors

                var viewModel = new StoreManagerViewModel
                {
                    Album = album,
                    Genres = storeDB.Genres.ToList(),
                    Artists = storeDB.Artists.ToList()
                };

                return View(viewModel);
            }
        }

        // GET: /StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = new StoreManagerViewModel
            {
                Album = storeDB.Albums.Single(a => a.AlbumId == id),
                Genres = storeDB.Genres.ToList(),
                Artists = storeDB.Artists.ToList()
            };

            return View(viewModel);
        }

        // POST: /StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var album = storeDB.Albums.Single(a => a.AlbumId == id);

            try
            {
                //Save Album

                UpdateModel(album, "Album");
                storeDB.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                var viewModel = new StoreManagerViewModel
                {
                    Album = album,
                    Genres = storeDB.Genres.ToList(),
                    Artists = storeDB.Artists.ToList()
                };
                return View(viewModel);
            }
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

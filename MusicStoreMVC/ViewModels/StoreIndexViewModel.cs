using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreMVC.ViewModels
{
    public class StoreIndexViewModel
    {
        public int NumberofGenres { get; set; }

        public List<string> Genres { get; set; }
    }
}
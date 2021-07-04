using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStoreMVC.Models;

namespace MusicStoreMVC.ViewModels
{
    public class StoreBrowseViewModel
    {
        public Genre Genre { get; set; }
        public List<Album> Albums { get; set; }
    }
}
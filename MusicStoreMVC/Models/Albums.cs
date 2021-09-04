﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MusicStoreMVC.Models
{
    [MetadataType(typeof(AlbumMetaData))]
    public partial class Album
    {
        //Validation Rules for the Album Class
        [Bind(Exclude = "AlbumId")]
        public class AlbumMetaData
        {
            [ScaffoldColumn(false)]
            public object AlbumId { get; set; }

            [DisplayName("Genre")]
            public object GenreId { get; set; }

            [DisplayName("Artist")]
            public object ArtistId { get; set; }

            [Required(ErrorMessage = "An Album Title is required")]
            [StringLength(160)]
            public object Title { get; set; }

            [DisplayName("Album Art URL")]
            [StringLength(1024)]
            public object AlbumArtUrl { get; set; }

            [Required(ErrorMessage = "Price is required")]
            [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
            public object Price { get; set; }
        }
    }
}
﻿using Evo.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Models.ViewModels
{
    public class SeriesViewModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }
        public IEnumerable<RatingViewModel> Ratings { get; set; }
        public IEnumerable<StarViewModel> Stars { get; set; }
    }
}
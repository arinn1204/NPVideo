using System;
using System.Collections.Generic;
using Evo.WebApi.Models.Enums;

namespace Evo.WebApi.Models.ViewModels
{
    public class VideoViewModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string MpaaRating { get; set; }
        public decimal Runtime { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Resolution { get; set; }
        public string Codec { get; set; }
        public VideoType VideoType { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
        public IEnumerable<RatingViewModel> Ratings { get; set; }
        public IEnumerable<StarViewModel> Stars { get; set; }
    }
}
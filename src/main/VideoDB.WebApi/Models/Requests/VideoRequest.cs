using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evo.WebApi.Models.Enums;

namespace Evo.WebApi.Models.Requests
{
    public class VideoRequest
    {
        [Required] public string VideoId { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Plot { get; set; }

        [Required] public virtual VideoType Type { get; set; }

        [Required] public DateTime ReleaseDate { get; set; }

        public decimal Runtime { get; set; }
        public string MpaaRating { get; set; }
        public string Resolution { get; set; }
        public string Codec { get; set; }

        public IEnumerable<GenreRequest> Genres { get; set; }
        public IEnumerable<StarRequest> Writers { get; set; }
        public IEnumerable<StarRequest> Directors { get; set; }
        public IEnumerable<StarRequest> Actors { get; set; }
        public IEnumerable<StarRequest> Producers { get; set; }
        public IEnumerable<RatingRequest> Ratings { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evo.WebApi.Models.Enums;
using Microsoft.Data.SqlClient;

namespace Evo.WebApi.Models.Requests
{
    public class VideoRequest
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal? Runtime { get; set; }
        public string MpaaRating { get; set; }
        public string Resolution { get; set; }
        public string Codec { get; set; }
        public string Extended { get; set; }
        public VideoType Type => VideoType.Movie;
        public IEnumerable<GenreRequest> Genres { get; set; }
        public IEnumerable<StarRequest> Writers { get; set; }
        public IEnumerable<StarRequest> Directors { get; set; }
        public IEnumerable<StarRequest> Actors { get; set; }
        public IEnumerable<StarRequest> Producers { get; set; }
        public IEnumerable<RatingRequest> Ratings { get; set; }

    }
}
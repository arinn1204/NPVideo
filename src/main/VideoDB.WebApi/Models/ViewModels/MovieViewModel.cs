using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Evo.WebApi.Models.Enums;

namespace Evo.WebApi.Models.ViewModels
{
    public class MovieViewModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string MpaaRating { get; set; }
        public decimal Runtime { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public VideoType VideoType { get; set; }

        [JsonIgnore]
        public bool IsUpdated { get; set; }
    }
}
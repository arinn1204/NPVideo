using Evo.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Models.ViewModels
{
    public class TvEpisode
    {
        public string VideoId { get; set; }
        public string MpaaRating { get; set; }
        public decimal Runtime { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeName { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }


        [JsonIgnore]
        public bool IsUpdated { get; set; }
    }
}

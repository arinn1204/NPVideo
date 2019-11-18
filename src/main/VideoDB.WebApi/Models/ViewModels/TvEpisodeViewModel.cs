using System;
using Newtonsoft.Json;

namespace Evo.WebApi.Models.ViewModels
{
    public class TvEpisodeViewModel
    {
        [JsonProperty("SeriesImdbId")] public string VideoId { get; set; }

        [JsonProperty("EpisodeImdbId")] public string TvEpisodeId { get; set; }

        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Resolution { get; set; }
        public string Codec { get; set; }
        public string Plot { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Evo.WebApi.Models.Enums;

namespace Evo.WebApi.Models.Requests
{
    public class TvEpisodeRequest : VideoRequest
    {
        public override VideoType Type => VideoType.Episode;

        public string TvEpisodeId { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public string EpisodeName { get; set; }
        public DateTime EpisodeReleaseDate { get; set; }
        public string EpisodePlot { get; set; }
    }
}
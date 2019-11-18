using System.ComponentModel.DataAnnotations;
using Evo.WebApi.Models.Enums;

namespace Evo.WebApi.Models.Requests
{
    public class TvEpisodeRequest : VideoRequest
    {
        public override VideoType Type => VideoType.Series;

        [Required] public string TvEpisodeId { get; set; }

        [Required] public int SeasonNumber { get; set; }

        [Required] public int EpisodeNumber { get; set; }

        public string EpisodeName { get; set; }
    }
}
using Evo.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Resolution { get; set; }
        public string Codec { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
        public IEnumerable<RatingViewModel> Ratings { get; set; }
        public IEnumerable<StarViewModel> Stars { get; set; }
    }
}

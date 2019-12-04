using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Evo.WebApi.Models.DataModel
{
    [SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "Used for database model mapping")]
    public class TvEpisodeDataModel
    {
        public int tv_episode_id { get; set; }
        public int series_id { get; set; }
        public string imdb_id { get; set; }
        public int season_number { get; set; }
        public int episode_number { get; set; }
        public string episode_name { get; set; }
        public decimal runtime { get; set; }
        public string rating { get; set; }
        public DateTime release_date { get; set; }
        public string plot { get; set; }
        public bool updated { get; set; }
    }
}

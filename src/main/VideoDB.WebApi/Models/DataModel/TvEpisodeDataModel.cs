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
        public string episode_imdb_id { get; set; }
        public int season_number { get; set; }
        public int episode_number { get; set; }
        public string episode_name { get; set; }
        public decimal runtime { get; set; }
        public string rating { get; set; }
        public DateTime release_date { get; set; }
        public string plot { get; set; }
        public string resolution { get; set; }
        public string codec { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string suffix { get; set; }
        public string person_role { get; set; }
        public string genre_name { get; set; }
        public string rating_source { get; set; }
        public decimal rating_value { get; set; }
    }
}

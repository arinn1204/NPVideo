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
    public class VideoDataModel
    {
        public string imdb_id { get; set; }
        public string movie_title { get; set; }
        public string movie_rating { get; set; }
        public decimal runtime { get; set; }
        public string plot { get; set; }
        public DateTime release_date { get; set; }
        public string resolution { get; set; }
        public string codec { get; set; }
        public string genre_name { get; set; }
        public string person_first_name { get; set; }
        public string person_middle_name { get; set; }
        public string person_last_name { get; set; }
        public string suffix { get; set; }
        public string person_role { get; set; }
        public string rating_source { get; set; }
        public string rating_value { get; set; }
    }
}

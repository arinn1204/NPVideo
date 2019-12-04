using System;
using System.Diagnostics.CodeAnalysis;

namespace Evo.WebApi.Models.DataModel
{
    [SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "Used for database model mapping")]
    public class MovieDataModel
    {
        public int video_id { get; set; }
        public string imdb_id { get; set; }
        public string movie_title { get; set; }
        public string movie_rating { get; set; }
        public decimal runtime { get; set; }
        public string plot { get; set; }
        public DateTime release_date { get; set; }
        public bool updated { get; set; }
    }
}

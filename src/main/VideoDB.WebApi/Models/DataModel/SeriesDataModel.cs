﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Evo.WebApi.Models.DataModel
{
    [SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "Used for database model mapping")]
    public class SeriesDataModel
    {
        public string imdb_id { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public string plot { get; set; }
        public DateTime release_date { get; set; }
        public string genre_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string suffix { get; set; }
        public string person_role { get; set; }
        public string rating_source { get; set; }
        public decimal rating_value { get; set; }
    }
}

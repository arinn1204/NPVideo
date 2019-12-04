using Evo.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Models.ViewModels
{
    public class SeriesViewModel
    {
        [JsonIgnore]
        public int SeriesId { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        [JsonIgnore]
        public bool IsUpdated { get; set; }
    }
}

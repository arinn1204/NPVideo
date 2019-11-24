using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VideoDB.WebApi.Models.ViewModels;

namespace Evo.WebApi.Models.ViewModels
{
    public class TvEpisodeViewModel
    {
        public SeriesViewModel Series { get; set; }
        public TvEpisode Episode { get; set; }
    }

}
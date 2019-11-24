﻿using Evo.WebApi.Models;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evo.WebApi.Services.Interfaces
{
    public interface IVideoService
    {
        VideoViewModel UpsertVideo(VideoRequest video);
        TvEpisodeViewModel UpsertTvEpisode(TvEpisodeRequest tvEpisode);
    }
}

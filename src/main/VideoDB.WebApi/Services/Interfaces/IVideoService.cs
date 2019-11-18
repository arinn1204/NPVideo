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
        Task<VideoViewModel> UpsertVideo(VideoRequest video);
        Task<VideoViewModel> UpsertTvEpisode(VideoRequest video);
    }
}
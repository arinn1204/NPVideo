﻿using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using System.Collections.Generic;

namespace VideoDB.WebApi.Repositories.Interfaces
{
    public interface ITvEpisodeRepository
    {

        (IEnumerable<VideoDataModel> videoDataModels, IEnumerable<TvEpisodeDataModel> tvDataModels)
            UpsertTvEpisode(TvEpisodeRequest tvEpisode);
    }
}
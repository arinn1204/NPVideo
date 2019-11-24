using Evo.WebApi.Models;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evo.WebApi.Repositories.Interfaces
{
    public interface IVideoRepository
    {
        IEnumerable<VideoDataModel> UpsertVideo(VideoRequest video);
    }
}
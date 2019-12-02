using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using Evo.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Evo.WebApi.Controllers
{
    [Route("api/videos/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TvEpisodesController : Controller
    {
        private readonly IVideoService _service;

        public TvEpisodesController(IVideoService service)
        {
            _service = service;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult UpsertTvEpisode([FromBody] TvEpisodeRequest request)
        {
            var result = CallService(
                request,
                _service.UpsertTvEpisode,
                out var error);

            return error ?? 
                (result.Episode.All(a => a.IsUpdated)
                ? NoContent() as IActionResult
                : Created($"/videos/tvEpisodes/{request.TvEpisodeId}", result) as IActionResult);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TvEpisodeViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult GetTvEpisodes()
        {
            var result = CallService(
                null,
                _ => _service.GetTvEpisodes(),
                out var error);

            return error ?? Ok(result);
        }

        private T CallService<T>(TvEpisodeRequest request, Func<TvEpisodeRequest, T> getResults, out ObjectResult errorResponse)
        {
            var result = default(T);
            try
            {
                result = getResults(request);
                errorResponse = null;
            }
            catch (Exception e)
            {
                var response = new ErrorResponse
                {
                    Error = e.Message,
                    StackTrace = e.StackTrace
                };

                errorResponse = StatusCode(500, response);
            }

            return result;
        }
    }
}
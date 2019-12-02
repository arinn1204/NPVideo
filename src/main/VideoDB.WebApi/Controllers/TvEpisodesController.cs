using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using Evo.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VideoDB.WebApi.Models.ViewModels;

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
        public IActionResult GetAllTvEpisodes()
        {
            return GetTvEpisodes();
        }

        [HttpGet("shows")]
        [ProducesResponseType(typeof(IEnumerable<SeriesViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllTvShows()
        {
            return GetTvShows();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<TvEpisodeViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult GetSpecificTvEpisode([FromRoute] string id)
        {
            return GetTvEpisodes(id);
        }

        [HttpGet("shows/{id}")]
        [ProducesResponseType(typeof(IEnumerable<SeriesViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult GetSpecificTvShow([FromRoute] string id)
        {
            return GetTvShows(id);
        }


        private IActionResult GetTvShows(string id = null)
        {
            var result = CallService(
                            null,
                            _ => _service.GetTvShows(id),
                            out var error);

            return error ?? Ok(result);
        }

        private IActionResult GetTvEpisodes(string id = null)
        {
            var result = CallService(
                            null,
                            _ => _service.GetTvEpisodes(id),
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
            catch (EvoNotFoundException e)
            {
                var response = new ErrorResponse
                {
                    Error = e.Message
                };

                errorResponse = new NotFoundObjectResult(response);
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
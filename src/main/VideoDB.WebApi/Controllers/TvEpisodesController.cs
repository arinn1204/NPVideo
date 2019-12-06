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
using VideoDB.WebApi.Controllers;
using VideoDB.WebApi.Models.ViewModels;

namespace Evo.WebApi.Controllers
{
    [Route("api/videos/[controller]")]
    public class TvEpisodesController : BaseController
    {
        private readonly IVideoService _service;

        public TvEpisodesController(IVideoService service)
        {
            _service = service;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpsertTvEpisode([FromBody] TvEpisodeRequest request)
        {
            var result = _service.UpsertTvEpisode(request);

            return result.Episode.All(a => a.IsUpdated)
                ? NoContent() as IActionResult
                : Created($"/videos/tvEpisodes/{request.TvEpisodeId}", result) as IActionResult;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TvEpisodeViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAllTvEpisodes()
        {
            return Ok(_service.GetTvEpisodes());
        }

        [HttpGet("shows")]
        [ProducesResponseType(typeof(IEnumerable<SeriesViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAllTvShows()
        {
            return Ok(_service.GetTvShows());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<TvEpisodeViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetSpecificTvEpisode([FromRoute] string id)
        {
            ValidateId(id);
            return Ok(_service.GetTvEpisodes(id));
        }

        [HttpGet("shows/{id}")]
        [ProducesResponseType(typeof(IEnumerable<SeriesViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetSpecificTvShow([FromRoute] string id)
        {
            ValidateId(id);
            return Ok(_service.GetTvShows(id));
        }
    }
}
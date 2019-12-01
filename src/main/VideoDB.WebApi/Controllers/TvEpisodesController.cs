﻿using System;
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
        private readonly IMovieService _service;

        public TvEpisodesController(IMovieService service)
        {
            _service = service;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult UpsertTvEpisode([FromBody] TvEpisodeRequest request)
        {
            TvEpisodeViewModel result;
            try
            {
                result = _service.UpsertTvEpisode(request);
            }
            catch (Exception e)
            {
                var response = new ErrorResponse
                {
                    Error = JsonConvert.SerializeObject(e)
                };

                return StatusCode(500, response);
            }

            return result.Episode.IsUpdated
                ? NoContent() as IActionResult
                : Created($"/videos/tvEpisodes/{request.TvEpisodeId}", result) as IActionResult;
        }
    }
}
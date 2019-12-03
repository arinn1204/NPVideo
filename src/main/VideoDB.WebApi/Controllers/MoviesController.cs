using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evo.WebApi.Exceptions;
using Evo.WebApi.Models;
using Evo.WebApi.Models.Requests;
using Evo.WebApi.Models.ViewModels;
using Evo.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VideoDB.WebApi.Controllers;

namespace Evo.WebApi.Controllers
{
    [Route("api/videos/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MoviesController : BaseController
    {
        private readonly IVideoService _videoService;

        public MoviesController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpsertVideo([FromBody] MovieRequest request)
        {
            var result = _videoService.UpsertMovie(request);

            return result.All(a => a.IsUpdated)
                ? NoContent() as IActionResult
                : Created($"/videos/movies/{request.VideoId}", result) as IActionResult;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MovieViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAllMovies()
        {
            return Ok(_videoService.GetMovies());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<MovieViewModel>), StatusCodes.Status200OK)]
        public IActionResult GetAllMovies(string id)
        {
            return Ok(_videoService.GetMovies(id));
        }

    }
}
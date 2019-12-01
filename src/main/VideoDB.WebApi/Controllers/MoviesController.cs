using System;
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

namespace Evo.WebApi.Controllers
{
    [Route("api/videos/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _videoService;

        public MoviesController(IMovieService videoService)
        {
            _videoService = videoService;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult UpsertVideo([FromBody] MovieRequest request)
        {
            MovieViewModel result;
            try
            {
                result = _videoService.UpsertMovie(request);
            }
            catch(Exception e)
            {
                var response = new ErrorResponse
                {
                    Error = JsonConvert.SerializeObject(e)
                };

                return StatusCode(500, response);
            }

            return result.IsUpdated
                ? NoContent() as IActionResult
                : Created($"/videos/movies/{request.VideoId}", result) as IActionResult;
        }
    }
}
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

namespace Evo.WebApi.Controllers
{
    [Route("api/videos/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MoviesController : Controller
    {
        private readonly IVideoService _videoService;

        public MoviesController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult UpsertVideo([FromBody] MovieRequest request)
        {
            var result = CallService(
                request,
                _videoService.UpsertMovie,
                out var error);

            return error ?? (result.All(a => a.IsUpdated)
                ? NoContent() as IActionResult
                : Created($"/videos/movies/{request.VideoId}", result) as IActionResult);
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MovieViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllMovies()
        {
            return GetMovies();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<MovieViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllMovies(string id)
        {
            return GetMovies(id);
        }

        private IActionResult GetMovies(string imdbId = null)
        {
            var result = CallService(
                            null,
                            _ => _videoService.GetMovies(imdbId),
                            out var error);

            return error ?? Ok(result);
        }

        private T CallService<T>(MovieRequest request, Func<MovieRequest, T> getResults, out ObjectResult errorResponse)
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
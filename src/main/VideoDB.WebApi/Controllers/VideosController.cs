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
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VideosController : Controller
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddVideo([FromBody] VideoRequest request)
        {
            var result = default(VideoViewModel);

            try
            {
                result = await _videoService.UpsertVideo(request);
            }
            catch (EvoBadRequestException e)
            {
                var badRequest = new BadRequest
                {
                    Id = request.VideoId,
                    Message = e.Message
                };

                return new BadRequestObjectResult(badRequest);
            }
            catch(Exception e)
            {
                var response = new ErrorResponse
                {
                    Error = JsonConvert.SerializeObject(e)
                };

                return StatusCode(500, @"<html>Hello! This is not ready.</html>");
            }

            return Created($"/videos/{request.VideoId}", result);
        }
    }
}
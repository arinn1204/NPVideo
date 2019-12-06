using Evo.WebApi.Exceptions;
using Evo.WebApi.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class BaseController : Controller
    {
        protected void ValidateId(string id)
        {
            var regex = new Regex(@"^tt\d{7,9}$");
            var matcher = regex.Match(id);

            if (!matcher.Success)
            {
                throw new EvoBadRequestException(id + " is an invalid format. The required format must match: 'tt\\d{7,9}'");
            }
        }
    }
}

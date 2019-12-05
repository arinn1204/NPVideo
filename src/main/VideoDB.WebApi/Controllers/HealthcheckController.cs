﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoDB.WebApi.Controllers
{
    [Route("/[controller]")]
    public class HealthcheckController : BaseController
    {
        [HttpGet]
        public IActionResult Healthcheck()
        {
            return Ok(new
            {
                AddedVariable = Environment.GetEnvironmentVariable("SampleApplicationVariable")
            });
        }
    }
}

using ApiNetCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class datetimeController : ControllerBase
    {
        private readonly ILogger<datetimeController> _logger;
        private readonly IDatetimeRepository _datetimeRepository;
        public datetimeController(ILogger<datetimeController> logger, IDatetimeRepository datetimeRepository)
        {
            _logger = logger;
            _datetimeRepository = datetimeRepository;
        }
        [HttpGet]
        public IActionResult GetDateTime()
        {
            try
            {
                var data = _datetimeRepository.GetDateTime();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get data");
                return new StatusCodeResult(500);
            }
        }
    }
}

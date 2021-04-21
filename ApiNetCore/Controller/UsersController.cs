using ApiNetCore.Domain;
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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;
        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUser()
        {
            try
            {
                var data = _userRepository.GetUser();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get data");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult PostNewUser([FromBody] Users users)
        {
            try
            {
                var data = _userRepository.PostNewUser(users);
                var res = data.FirstOrDefault();
                if (res.name == null)
                {
                    _logger.LogWarning($"User:{users.name} already exists.");
                    return Problem($"User:{users.name} already exists.",null,406);
                } 
                else
                {
                    _logger.LogInformation($"User:{users.name} successfully created.");
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get data");
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var data = _userRepository.DeleteUser(id);
                var res = data.FirstOrDefault();
                if (res == null)
                {
                    return Accepted($"Id:{id} delete.");
                }
                else
                {
                    _logger.LogWarning($"Id:{id} not exists.");
                    return Problem($"Id:{id} not exists.", null, 406);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get data");
                return new StatusCodeResult(500);
            }
        }
    }
}

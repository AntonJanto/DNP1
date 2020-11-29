using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using FamilyAPI.Middleware.Authentication;
using FamilyAPI.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Register a specific user with username, password and basic permissions - 0
        /// </summary>
        /// <param name="user">user credentials</param>
        /// <returns>Nothing</returns>
        /// <response code="200">New User is registered</response>
        /// <response code="400">User may already exist</response>
        /// <response code="500">Oopsie</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RegisterUserAsync([FromBody]User user)
        {
            try
            {
                await userService.RegisterUserAsync(user.Username, user.Password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User data</returns>
        /// <response code="200">User is authenticated</response>
        /// <response code="400">User does not exist / incorrect password</response>
        /// <response code="500">Oopsie</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery] string username, [FromBody] string password)
        {
            try
            {
                User user = await userService.ValidateUserAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

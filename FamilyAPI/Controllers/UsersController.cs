using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyAPI.Data.Authentication;
using FamilyAPI.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPut]
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

        [HttpPost]
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

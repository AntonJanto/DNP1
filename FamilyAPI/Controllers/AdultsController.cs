using System.Threading.Tasks;
using FamilyAPI.Middleware.Families;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdultsController : ControllerBase
    {
        private readonly IFamilyService familyService;
        public AdultsController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        /// <summary>
        /// Remove an adult
        /// </summary>
        /// <param name="adultId">adult id</param>
        [HttpDelete]
        [Route("{adultId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RemoveAdult([FromRoute] int adultId)
        {
            var removed = await familyService.RemoveAdultAsync(adultId);
            if (removed)
                return NoContent();
            else
                return StatusCode(500);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyAPI.Data.Families;
using FamilyAPI.Models.Families;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FamilyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilyService familyService;

        public FamiliesController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                var families = await familyService.GetFamiliesAsync();
                return Ok(families);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Family>> AddFamilyAsync([FromBody]Family family)
        {
            try
            {
                var newFamily = await familyService.AddFamilyAsync(family);
                return StatusCode(201, newFamily);
            }
            catch (Exception e)
            {
                if (e.Message == "Family already exists")
                    return BadRequest(e.Message);
                else
                    return StatusCode(500, e.Message);
            }     
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RemoveFamily([FromQuery] string streetName, [FromQuery] int houseNumber)
        {
            var removed = await familyService.RemoveFamilyAsync(
                new Family() { 
                    StreetName = streetName, 
                    HouseNumber = houseNumber 
                });
            if (removed)
                return NoContent();
            else
                return StatusCode(500);
        }
    }
}

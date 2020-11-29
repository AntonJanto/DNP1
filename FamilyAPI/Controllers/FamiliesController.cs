using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using FamilyAPI.Middleware.Families;
using FamilyAPI.Models.Families;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilyService familyService;

        public FamiliesController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        /// <summary>
        /// Get all families
        /// </summary>
        /// <returns>List of all families</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Add a family to all families. Including all adults in the family
        /// </summary>
        /// <param name="family">Family to add</param>
        /// <returns>Created family</returns>
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

        /// <summary>
        /// Remove a family from all families
        /// </summary>
        /// <param name="streetName">street name of the house</param>
        /// <param name="houseNumber">number of the house</param>
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

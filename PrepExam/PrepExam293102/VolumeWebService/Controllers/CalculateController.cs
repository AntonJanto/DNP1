using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VolumeWebService.Data;
using VolumeWebService.VolumeCalculator;

namespace VolumeWebService.Controllers
{
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly Calculator _calculator;
        private readonly VolumeResultDbContext _volumeResultDbContext;

        public CalculateController(Calculator calculator, VolumeResultDbContext volumeResultDbContext)
        {
            _calculator = calculator;
            _volumeResultDbContext = volumeResultDbContext;
        }

        [HttpGet]
        [Route("[controller]/cylinder")]
        public ActionResult<VolumeResult> CalculateCylinderVolume([FromQuery] double height, [FromQuery] double radius)
        {
            if (height > 0 && radius > 0)
            {
                var volume = _calculator.CalculateVolumeCylinder(radius, height);
                var result = CreateVolumeResult("cylinder", height, radius, volume);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[controller]/cone")]
        public ActionResult<VolumeResult> CalculateConeVolume([FromQuery] double height, [FromQuery] double radius)
        {
            if (height > 0 && radius > 0)
            {
                var volume = _calculator.CalculateVolumeCone(radius, height);
                var result = CreateVolumeResult("cone", height, radius, volume);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[controller]/cylinder")]
        public async Task<ActionResult<VolumeResult>> CalculateAndSaveCylinderVolumeAsync([FromQuery] double height, [FromQuery] double radius)
        {
            if (height > 0 && radius > 0)
            {
                var volume = _calculator.CalculateVolumeCylinder(radius, height);
                var result = CreateVolumeResult("cylinder", height, radius, volume);
                _volumeResultDbContext.VolumeResults.Add(result);
                await _volumeResultDbContext.SaveChangesAsync();
                return Created($"http://localhost:5000/calculate/cylinder?height={height}&radius={radius}", result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[controller]/cone")]
        public async Task<ActionResult<VolumeResult>> CalculateAndSaveConeVolumeAsync([FromQuery] double height, [FromQuery] double radius)
        {
            if (height > 0 && radius > 0)
            {
                var volume = _calculator.CalculateVolumeCone(radius, height);
                var result = CreateVolumeResult("cone", height, radius, volume);
                _volumeResultDbContext.VolumeResults.Add(result);
                await _volumeResultDbContext.SaveChangesAsync();
                return Created($"http://localhost:5000/calculate/cone?height={height}&radius={radius}", result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/volume-result")]
        public async Task<ActionResult<IList<VolumeResult>>> GetVolumeResultsAsync()
        {
            return _volumeResultDbContext.VolumeResults.ToList();
        }

        private static VolumeResult CreateVolumeResult(string type, double height, double radius, double volume)
        {
            return new()
            {
                Type = type,
                Height = height,
                Radius = radius,
                Volume = volume
            };
        }
    }
}
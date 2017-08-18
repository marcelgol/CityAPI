using City.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInteresetController : Controller
    {

        private ILogger<PointsOfInteresetController> _logger;

        private IMailService _mailService;


        public PointsOfInteresetController(ILogger<PointsOfInteresetController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;

        }

        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.ID == cityId);

                if (city == null)
                {
                    _logger.LogInformation($"City with Id {cityId} was not found.");
                    return NotFound();
                }

                return Ok(city.PointsOfInterest);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting POI for city {cityId}.", ex);
                return StatusCode(500, "Problem happened while handling your request.");
            }

            

            
                
        }

        [HttpGet("{cityId}/pointsofinterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.ID == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);

            if (pointsOfInterest == null)
            {
                return NotFound();
            }

            _mailService.Send("Mail Service","Mail SENT");

            return Ok(pointsOfInterest);
        }
        [HttpPost("{cityId}/pointsofinterest",Name ="GetPointOfInterest") ]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.ID == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var MaxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                                       c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointsOfInterestDto()
            {
                Id = ++MaxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new
            { cityId = cityId, id = finalPointOfInterest.Id },finalPointOfInterest);
        }
    }
}
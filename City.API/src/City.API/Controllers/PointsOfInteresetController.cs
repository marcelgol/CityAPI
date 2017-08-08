using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInteresetController : Controller
    {
        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.ID == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
                
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

            return Ok(pointsOfInterest);
        }
    }
}
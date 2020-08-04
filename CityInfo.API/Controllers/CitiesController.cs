using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")] // we could use "api/[controller]" and is a convention and referes to the firts naming part part of CitiesController
    public class CitiesController: ControllerBase // we could also inherit from Controller but that adds support also for views
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            //throw new Exception("Test exception!");
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);

            //return new JsonResult(
            //    CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id)
            //);
        }
    }
}

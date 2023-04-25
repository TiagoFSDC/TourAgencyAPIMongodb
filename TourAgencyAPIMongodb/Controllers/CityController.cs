using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourAgencyAPIMongodb.Models;
using TourAgencyAPIMongodb.Services;

namespace TourAgencyAPIMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        // Injeção de dependencia
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<City>> Get() => _cityService.Get();


        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<City> Get(string id)
        {
            var city = _cityService.Get(id);
            if (city == null) return NotFound();
            return city;
        }

        [HttpPost]
        public ActionResult<City> Create(City City)
        {
            //_CityService.Create(City);
            //return CreatedAtRoute("GetCity", new { id = City.Id}, City);
            return _cityService.Create(City);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, City City)
        {
            var c = _cityService.Get(id);
            if (c == null) return NotFound();
            _cityService.Update(id, City);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            _cityService.Delete(id);

            return Ok();
        }
    }
}

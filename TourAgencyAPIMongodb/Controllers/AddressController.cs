using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TourAgencyAPIMongodb.Models;
using TourAgencyAPIMongodb.Services;

namespace TourAgencyAPIMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;


        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var customer = _addressService.Get(id);
            if (customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            if (address.city.Id != String.Empty)
            {
                var cities = _cityService.Get(address.city.Id);
                address.city = cities;
            }
            else
            {
                var c = _cityService.Create(address.city);
                address.city = c;
            }
            return _addressService.Create(address);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Address address)
        {
            var c = _addressService.Get(id);
            if (c == null) return NotFound();
            _addressService.Update(id, address);
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

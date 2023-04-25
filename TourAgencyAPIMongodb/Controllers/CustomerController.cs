using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TourAgencyAPIMongodb.Config;
using TourAgencyAPIMongodb.Models;
using TourAgencyAPIMongodb.Services;

namespace TourAgencyAPIMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly AddressService _addressService;


        public CustomerController(CustomerService customerService, AddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            if (customer.address.Id != String.Empty)
            {
                var address = _addressService.Get(customer.address.Id);
                customer.address = address;
            }
            else
            {
                var c = _addressService.Create(customer.address);
                if(c.city.Id == String.Empty)
                {
                    return NotFound("Não foi possivel inserir");
                }
                customer.address = c;
            }
            return _customerService.Create(customer);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Customer customer)
        {
            var c = _customerService.Get(id);
            if (c == null) return NotFound();
            _customerService.Update(id, customer);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            _customerService.Delete(id);

            return Ok();
        }
    }
}

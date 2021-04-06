using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebAPIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerManagementRepository<Customer> _repository;
        public CustomerController(ICustomerManagementRepository<Customer> repository)
        {
            _repository = repository;

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                List<Customer> customers = (List<Customer>)_repository.GetAllData();
                return Ok(customers);
            }
            catch (Exception)
            {
                return BadRequest("Could not fetch the data");
            }

        }
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult Get(int id)
        {
            try
            {
                Customer customer = _repository.GetById(id);
                if (customer != null)
                    return Ok(customer);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NotFound();

        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _repository.Add(customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Customer object is null");
            try
            {
                _repository.Update(id, customer);
            }
            catch (Exception)
            {
                return BadRequest("Could not update Customer details");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Customer object is null");
            try
            {
                _repository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest("Could not delete Customer details");
            }
            return NoContent();

        }
    }
}

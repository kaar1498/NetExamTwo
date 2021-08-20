using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetExamTwo.Data;
using NetExamTwo.Models;
using NetExamTwo.Services;

namespace NetExamTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly NetExamTwoContext _context;

        private readonly GetCustomersService _getService;
        private readonly PostService _postService;
        private readonly PutService<Customer> _putService;
        private readonly DeleteService<Customer> _deleteService;
        public CustomersController(NetExamTwoContext context, ILogger<CustomersController> logger)
        {
            _context = context;
            _logger = logger;

            _postService = new PostService(context);
            _putService = new PutService<Customer>(context, context.Customers);
            _getService = new GetCustomersService(context);
            _deleteService = new DeleteService<Customer>(context, context.Customers, nameof(Customer));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer(int? id, bool withContactInfo, bool withContactList)
        {
            try
            {
                var customers = await _getService.GetAsync(id, withContactInfo, withContactList);

                if (customers == null)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}

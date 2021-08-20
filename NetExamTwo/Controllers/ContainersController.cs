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
    public class ContainersController : ControllerBase
    {
        private readonly ILogger<ContainersController> _logger;
        private readonly NetExamTwoContext _context;


        private readonly GetContainersService _getService;
        private readonly PostService _postService;
        private readonly PutService<Container> _putService;
        private readonly DeleteService<Container> _deleteService;
        public ContainersController(NetExamTwoContext context,ILogger<ContainersController> logger)
        {
            _context = context;
            _logger = logger;

            _postService = new PostService(context);
            _putService = new PutService<Container>(context, context.Containers);
            _getService = new GetContainersService(context);
            _deleteService = new DeleteService<Container>(context, context.Containers, nameof(Container));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Container>>> GetContainer(int? id, Status? status, bool WithStatusHistory = true)
        {
            try
            {
                IEnumerable<Container> containers = await _getService.GetAsync(status, id, WithStatusHistory);
                if (containers == null)
                {
                    return NotFound();
                }

                return Ok(containers);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer(int id, Container container)
        {
            if (id != container.CCTag)
            {
                return BadRequest();
            }

            _context.Entry(container).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
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
        public async Task<ActionResult<Container>> PostContainer(Container container)
        {
            _context.Containers.Add(container);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContainer", new { id = container.CCTag }, container);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContainerExists(int id)
        {
            return _context.Containers.Any(e => e.CCTag == id);
        }
    }
}

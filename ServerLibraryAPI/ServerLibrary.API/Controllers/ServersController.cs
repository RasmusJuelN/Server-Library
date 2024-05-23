using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.DTO.Models;
using ServerLibrary.Repo.Data;
using ServerLibrary.Repo.Interfaces;

namespace ServerLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IRepository<Server> _serverRepository;

        public ServersController(IRepository<Server> serverRepository)
        {
            _serverRepository = serverRepository;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Server>>> GetServers()
        {
            return Ok(await _serverRepository.GetAllAsync());
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Server>> GetServer(Guid id)
        {
            var server = await _serverRepository.GetByIdAsync(id);

            if (server == null)
            {
                return NotFound();
            }

            return server;
        }

        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServer(Guid id, Server server)
        {
            if (id != server.Id)
            {
                return BadRequest();
            }

            await _serverRepository.UpdateAsync(server);

            try
            {
                await _serverRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _serverRepository.ExistsAsync(id))
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

        // POST: api/Servers
        [HttpPost]
        public async Task<ActionResult<Server>> PostServer(Server server)
        {
            await _serverRepository.AddAsync(server);
            await _serverRepository.SaveChangesAsync();

            return CreatedAtAction("GetServer", new { id = server.Id }, server);
        }

        // DELETE: api/Servers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServer(Guid id)
        {
            await _serverRepository.DeleteAsync(id);
            await _serverRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

using ClassLibrary;
using ClassLibrary.DtoModels.Agency;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgencyController : ControllerBase
    {
        private readonly ClassDBContext _context;
        private readonly ILogger<AgencyController> _logger;

        public AgencyController(ClassDBContext context, ILogger<AgencyController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/agency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencyDto>>> GetAgencies()
        {
            try
            {
                var agencies = await _context.Agencies
                    .Select(a => new AgencyDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Description = a.Description,
                        DateCreated = a.DateCreated
                    })
                    .ToListAsync();

                return Ok(agencies);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in GetAgencies", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/agency/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AgencyDto>> GetAgency(int id)
        {
            try
            {
                var agency = await _context.Agencies.FindAsync(id);

                if (agency == null)
                    return NotFound($"Agency with ID {id} not found.");

                var agencyDto = new AgencyDto
                {
                    Id = agency.Id,
                    Name = agency.Name,
                    Description = agency.Description,
                    DateCreated = agency.DateCreated
                };

                return Ok(agencyDto);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in GetAgency", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/agency
        [HttpPost]
        public async Task<ActionResult<AgencyDto>> CreateAgency([FromBody] CreateAgencyDto createAgencyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var agency = new Agency
                {
                    Name = createAgencyDto.Name,
                    Description = createAgencyDto.Description,
                };

                _context.Agencies.Add(agency);
                await _context.SaveChangesAsync();

                var agencyDto = new AgencyDto
                {
                    Id = agency.Id,
                    Name = agency.Name,
                    Description = agency.Description,
                    DateCreated = agency.DateCreated
                };

                return CreatedAtAction(nameof(GetAgency), new { id = agency.Id }, agencyDto);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in CreateAgency", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT: api/agency/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<AgencyDto>> UpdateAgency(int id, [FromBody] UpdateAgencyDto updateAgencyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var agency = await _context.Agencies.FindAsync(id);
                if (agency == null)
                    return NotFound($"Agency with ID {id} not found.");

                agency.Name = updateAgencyDto.Name;
                agency.Description = updateAgencyDto.Description;

                _context.Agencies.Update(agency);
                await _context.SaveChangesAsync();

                var agencyDto = new AgencyDto
                {
                    Id = agency.Id,
                    Name = agency.Name,
                    Description = agency.Description,
                    DateCreated = agency.DateCreated
                };

                return Ok(agencyDto);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in UpdateAgency", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/agency/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgency(int id)
        {
            try
            {
                var agency = await _context.Agencies.FindAsync(id);
                if (agency == null)
                    return NotFound($"Agency with ID {id} not found.");

                _context.Agencies.Remove(agency);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in DeleteAgency", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // Helper method to log errors to the database
        private async Task LogErrorToDatabaseAsync(string context, Exception ex)
        {
            _logger.LogError($"{context}: {ex.Message}", ex);

            try
            {
                var errorLog = new ErrorLog
                {
                    ErrorMessage = ex.Message,
                    DateCreated = DateTime.UtcNow
                };

                _context.ErrorLogs.Add(errorLog);
                await _context.SaveChangesAsync();
            }
            catch (Exception logEx)
            {
                _logger.LogError($"Failed to log error to database: {logEx.Message}", logEx);
            }
        }
    }
}

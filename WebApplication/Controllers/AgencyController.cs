using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.DtoModels.Common;
using ClassLibrary.DtoModels.Agency;

namespace TheWebApplication.Controllers
{
    [ApiController]
    [Authorize]
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

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<AgencyDto>>>> GetAgencies()
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

                return Ok(new ApiResponse<IEnumerable<AgencyDto>>
                {
                    Success = true,
                    Message = "Agencies retrieved successfully",
                    Data = agencies
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAgencies: {ex.Message}", ex);
                return StatusCode(500, new ApiResponse<IEnumerable<AgencyDto>>
                {
                    Success = false,
                    Message = "Internal server error",
                    Errors = new List<string> { "An unexpected error occurred" }
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<AgencyDto>>> GetAgency(int id)
        {
            try
            {
                var agency = await _context.Agencies
                    .Include(a => a.Departments)
                    .Include(a => a.Locations)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (agency == null)
                    return NotFound(new ApiResponse<AgencyDto>
                    {
                        Success = false,
                        Message = "Agency not found",
                        Errors = new List<string> { $"Agency with ID {id} not found" }
                    });

                var agencyDto = new AgencyDto
                {
                    Id = agency.Id,
                    Name = agency.Name,
                    Description = agency.Description,
                    DateCreated = agency.DateCreated
                };

                return Ok(new ApiResponse<AgencyDto>
                {
                    Success = true,
                    Message = "Agency retrieved successfully",
                    Data = agencyDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAgency: {ex.Message}", ex);
                return StatusCode(500, new ApiResponse<AgencyDto>
                {
                    Success = false,
                    Message = "Internal server error",
                    Errors = new List<string> { "An unexpected error occurred" }
                });
            }
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult<ApiResponse<AgencyDto>>> CreateAgency([FromBody] CreateAgencyDto createAgencyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<AgencyDto>
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });

            try
            {
                var agency = new Agency
                {
                    Name = createAgencyDto.Name,
                    Description = createAgencyDto.Description,
                    // DateCreated = DateTime.UtcNow
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

                return CreatedAtAction(nameof(GetAgency), new { id = agency.Id },
                    new ApiResponse<AgencyDto>
                    {
                        Success = true,
                        Message = "Agency created successfully",
                        Data = agencyDto
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateAgency: {ex.Message}", ex);
                return StatusCode(500, new ApiResponse<AgencyDto>
                {
                    Success = false,
                    Message = "Internal server error",
                    Errors = new List<string> { "An unexpected error occurred" }
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult<ApiResponse<AgencyDto>>> UpdateAgency(int id, [FromBody] UpdateAgencyDto updateAgencyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<AgencyDto>
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });

            try
            {
                var agency = await _context.Agencies.FindAsync(id);
                if (agency == null)
                    return NotFound(new ApiResponse<AgencyDto>
                    {
                        Success = false,
                        Message = "Agency not found",
                        Errors = new List<string> { $"Agency with ID {id} not found" }
                    });

                agency.Name = updateAgencyDto.Name;
                agency.Description = updateAgencyDto.Description;

                await _context.SaveChangesAsync();

                var agencyDto = new AgencyDto
                {
                    Id = agency.Id,
                    Name = agency.Name,
                    Description = agency.Description,
                    DateCreated = agency.DateCreated
                };

                return Ok(new ApiResponse<AgencyDto>
                {
                    Success = true,
                    Message = "Agency updated successfully",
                    Data = agencyDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateAgency: {ex.Message}", ex);
                return StatusCode(500, new ApiResponse<AgencyDto>
                {
                    Success = false,
                    Message = "Internal server error",
                    Errors = new List<string> { "An unexpected error occurred" }
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteAgency(int id)
        {
            try
            {
                var agency = await _context.Agencies.FindAsync(id);
                if (agency == null)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Agency not found",
                        Errors = new List<string> { $"Agency with ID {id} not found" }
                    });

                _context.Agencies.Remove(agency);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Agency deleted successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteAgency: {ex.Message}", ex);
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "Internal server error",
                    Errors = new List<string> { "An unexpected error occurred" }
                });
            }
        }
    }
}

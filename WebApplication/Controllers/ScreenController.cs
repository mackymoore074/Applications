using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.DtoModels.Screen;
using ClassLibrary.Models;
using ClassLibrary;

namespace TheWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreenController : ControllerBase
    {
        private readonly ClassDBContext _context;
        private readonly ILogger<ScreenController> _logger;

        public ScreenController(ClassDBContext context, ILogger<ScreenController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/screen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScreenDto>>> GetScreens()
        {
            try
            {
                var screens = await _context.Screens
                    .Select(s => new ScreenDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        ScreenType = s.ScreenType,
                        IsOnline = s.IsOnline,
                        StatusMessage = s.StatusMessage
                    })
                    .ToListAsync();

                return Ok(screens);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in GetScreens", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/screen/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ScreenDto>> GetScreen(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var screen = await _context.Screens.FindAsync(id);

                if (screen == null)
                {
                    return NotFound($"Screen with ID {id} not found.");
                }

                return Ok(new ScreenDto
                {
                    Id = screen.Id,
                    Name = screen.Name,
                    ScreenType = screen.ScreenType,
                    IsOnline = screen.IsOnline,
                    StatusMessage = screen.StatusMessage
                });
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in GetScreen", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/screen
        [HttpPost]
        public async Task<ActionResult<ScreenDto>> CreateScreen([FromBody] CreateScreenDto createScreenDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();
                return BadRequest(errors);
            }

            try
            {
                var screen = new Screen
                {
                    Name = createScreenDto.Name,
                    LocationId = createScreenDto.LocationId,
                    DepartmentId = createScreenDto.DepartmentId,
                    AgencyId = createScreenDto.AgencyId,
                    ScreenType = createScreenDto.ScreenType,
                    IsOnline = createScreenDto.IsOnline,
                    StatusMessage = createScreenDto.StatusMessage,
                    MACAddress = createScreenDto.MACAddress
                };

                // Add screen to the context and try saving to the database
                _context.Screens.Add(screen);
                await _context.SaveChangesAsync(); // This is where the error may occur

                var screenDto = new ScreenDto
                {
                    Id = screen.Id,
                    Name = screen.Name,
                    ScreenType = screen.ScreenType,
                    IsOnline = screen.IsOnline,
                    StatusMessage = screen.StatusMessage
                };

                return CreatedAtAction(nameof(GetScreen), new { id = screen.Id }, screenDto);
            }
            catch (DbUpdateException dbEx)
            {
                // Log the specific database update error
                _logger.LogError("Database update error: {Message}, InnerException: {InnerException}, StackTrace: {StackTrace}",
                    dbEx.Message, dbEx.InnerException?.Message, dbEx.StackTrace);
                return StatusCode(500, "Database update failed.");
            }
            catch (Exception ex)
            {
                // Log general errors
                _logger.LogError("An unexpected error occurred: {0}", ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT: api/screen/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScreen(int id, [FromBody] UpdateScreenDto updateScreenDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var screen = await _context.Screens.FindAsync(id);
                if (screen == null)
                    return NotFound($"Screen with ID {id} not found.");

                screen.Name = updateScreenDto.Name;
                screen.DepartmentId = updateScreenDto.DepartmentId;
                screen.LocationId = updateScreenDto.LocationId;
                screen.ScreenType = updateScreenDto.ScreenType;
                screen.IsOnline = updateScreenDto.IsOnline;
                screen.StatusMessage = updateScreenDto.StatusMessage;

                _context.Entry(screen).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var screenDto = new ScreenDto
                {
                    Id = screen.Id,
                    Name = screen.Name,
                    ScreenType = screen.ScreenType,
                    IsOnline = screen.IsOnline,
                    StatusMessage = screen.StatusMessage
                };

                return Ok(screenDto);
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in UpdateScreen", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/screen/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen(int id)
        {
            try
            {
                var screen = await _context.Screens.FindAsync(id);
                if (screen == null)
                    return NotFound($"Screen with ID {id} not found.");

                _context.Screens.Remove(screen);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await LogErrorToDatabaseAsync("Error in DeleteScreen", ex);
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

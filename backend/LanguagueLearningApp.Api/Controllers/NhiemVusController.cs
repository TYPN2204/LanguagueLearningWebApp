using Microsoft.AspNetCore.Mvc;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NhiemVusController : ControllerBase
{
    private readonly INhiemVuService _nhiemVuService;

    public NhiemVusController(INhiemVuService nhiemVuService)
    {
        _nhiemVuService = nhiemVuService;
    }

    /// <summary>
    /// Get all quests
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<NhiemVu>>> GetAllNhiemVus()
    {
        var nhiemVus = await _nhiemVuService.GetAllNhiemVusAsync();
        return Ok(nhiemVus);
    }

    /// <summary>
    /// Get a specific quest by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<NhiemVu>> GetNhiemVuById(int id)
    {
        var nhiemVu = await _nhiemVuService.GetNhiemVuByIdAsync(id);
        
        if (nhiemVu == null)
        {
            return NotFound(new { message = $"Quest with ID {id} not found." });
        }
        
        return Ok(nhiemVu);
    }

    /// <summary>
    /// Create a new quest
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NhiemVu>> CreateNhiemVu([FromBody] NhiemVu nhiemVu)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdNhiemVu = await _nhiemVuService.CreateNhiemVuAsync(nhiemVu);
            return CreatedAtAction(
                nameof(GetNhiemVuById), 
                new { id = createdNhiemVu.MaNhiemVu }, 
                createdNhiemVu
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing quest
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateNhiemVu(int id, [FromBody] NhiemVu nhiemVu)
    {
        if (id != nhiemVu.MaNhiemVu)
        {
            return BadRequest(new { message = "ID mismatch between route and body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _nhiemVuService.UpdateNhiemVuAsync(nhiemVu);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Delete a quest
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteNhiemVu(int id)
    {
        try
        {
            await _nhiemVuService.DeleteNhiemVuAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

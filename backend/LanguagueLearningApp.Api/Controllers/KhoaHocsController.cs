using Microsoft.AspNetCore.Mvc;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KhoaHocsController : ControllerBase
{
    private readonly IKhoaHocService _khoaHocService;

    public KhoaHocsController(IKhoaHocService khoaHocService)
    {
        _khoaHocService = khoaHocService;
    }

    /// <summary>
    /// Get all courses
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<KhoaHoc>>> GetAllKhoaHocs()
    {
        var khoaHocs = await _khoaHocService.GetAllKhoaHocsAsync();
        return Ok(khoaHocs);
    }

    /// <summary>
    /// Get a specific course by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<KhoaHoc>> GetKhoaHocById(int id)
    {
        var khoaHoc = await _khoaHocService.GetKhoaHocByIdAsync(id);
        
        if (khoaHoc == null)
        {
            return NotFound(new { message = $"Course with ID {id} not found." });
        }
        
        return Ok(khoaHoc);
    }

    /// <summary>
    /// Create a new course
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<KhoaHoc>> CreateKhoaHoc([FromBody] KhoaHoc khoaHoc)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdKhoaHoc = await _khoaHocService.CreateKhoaHocAsync(khoaHoc);
            return CreatedAtAction(
                nameof(GetKhoaHocById), 
                new { id = createdKhoaHoc.MaKhoaHoc }, 
                createdKhoaHoc
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing course
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateKhoaHoc(int id, [FromBody] KhoaHoc khoaHoc)
    {
        if (id != khoaHoc.MaKhoaHoc)
        {
            return BadRequest(new { message = "ID mismatch between route and body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _khoaHocService.UpdateKhoaHocAsync(khoaHoc);
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
    /// Delete a course
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteKhoaHoc(int id)
    {
        try
        {
            await _khoaHocService.DeleteKhoaHocAsync(id);
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

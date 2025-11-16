using Microsoft.AspNetCore.Mvc;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HocSinhsController : ControllerBase
{
    private readonly IHocSinhService _hocSinhService;

    public HocSinhsController(IHocSinhService hocSinhService)
    {
        _hocSinhService = hocSinhService;
    }

    /// <summary>
    /// Get all students
    /// </summary>
    /// <returns>List of all students</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<HocSinh>>> GetAllHocSinhs()
    {
        var hocSinhs = await _hocSinhService.GetAllHocSinhsAsync();
        return Ok(hocSinhs);
    }

    /// <summary>
    /// Get a specific student by ID
    /// </summary>
    /// <param name="id">Student ID</param>
    /// <returns>Student details</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HocSinh>> GetHocSinhById(int id)
    {
        var hocSinh = await _hocSinhService.GetHocSinhByIdAsync(id);
        
        if (hocSinh == null)
        {
            return NotFound(new { message = $"Student with ID {id} not found." });
        }
        
        return Ok(hocSinh);
    }

    /// <summary>
    /// Create a new student
    /// </summary>
    /// <param name="hocSinh">Student data</param>
    /// <returns>Created student</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HocSinh>> CreateHocSinh([FromBody] HocSinh hocSinh)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdHocSinh = await _hocSinhService.CreateHocSinhAsync(hocSinh);
            return CreatedAtAction(
                nameof(GetHocSinhById), 
                new { id = createdHocSinh.MaHocSinh }, 
                createdHocSinh
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing student
    /// </summary>
    /// <param name="id">Student ID</param>
    /// <param name="hocSinh">Updated student data</param>
    /// <returns>No content</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateHocSinh(int id, [FromBody] HocSinh hocSinh)
    {
        if (id != hocSinh.MaHocSinh)
        {
            return BadRequest(new { message = "ID mismatch between route and body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _hocSinhService.UpdateHocSinhAsync(hocSinh);
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
    /// Delete a student
    /// </summary>
    /// <param name="id">Student ID</param>
    /// <returns>No content</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteHocSinh(int id)
    {
        try
        {
            await _hocSinhService.DeleteHocSinhAsync(id);
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

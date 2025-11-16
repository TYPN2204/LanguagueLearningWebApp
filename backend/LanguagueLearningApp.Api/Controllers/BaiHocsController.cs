using Microsoft.AspNetCore.Mvc;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaiHocsController : ControllerBase
{
    private readonly IBaiHocService _baiHocService;

    public BaiHocsController(IBaiHocService baiHocService)
    {
        _baiHocService = baiHocService;
    }

    /// <summary>
    /// Get all lessons
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BaiHoc>>> GetAllBaiHocs()
    {
        var baiHocs = await _baiHocService.GetAllBaiHocsAsync();
        return Ok(baiHocs);
    }

    /// <summary>
    /// Get a specific lesson by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaiHoc>> GetBaiHocById(int id)
    {
        var baiHoc = await _baiHocService.GetBaiHocByIdAsync(id);
        
        if (baiHoc == null)
        {
            return NotFound(new { message = $"Lesson with ID {id} not found." });
        }
        
        return Ok(baiHoc);
    }

    /// <summary>
    /// Create a new lesson
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaiHoc>> CreateBaiHoc([FromBody] BaiHoc baiHoc)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdBaiHoc = await _baiHocService.CreateBaiHocAsync(baiHoc);
            return CreatedAtAction(
                nameof(GetBaiHocById), 
                new { id = createdBaiHoc.MaBaiHoc }, 
                createdBaiHoc
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing lesson
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBaiHoc(int id, [FromBody] BaiHoc baiHoc)
    {
        if (id != baiHoc.MaBaiHoc)
        {
            return BadRequest(new { message = "ID mismatch between route and body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _baiHocService.UpdateBaiHocAsync(baiHoc);
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
    /// Delete a lesson
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBaiHoc(int id)
    {
        try
        {
            await _baiHocService.DeleteBaiHocAsync(id);
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

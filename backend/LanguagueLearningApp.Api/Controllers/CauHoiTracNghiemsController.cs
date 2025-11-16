using Microsoft.AspNetCore.Mvc;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CauHoiTracNghiemsController : ControllerBase
{
    private readonly ICauHoiTracNghiemService _cauHoiTracNghiemService;

    public CauHoiTracNghiemsController(ICauHoiTracNghiemService cauHoiTracNghiemService)
    {
        _cauHoiTracNghiemService = cauHoiTracNghiemService;
    }

    /// <summary>
    /// Get all multiple choice questions
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CauHoiTracNghiem>>> GetAllCauHoiTracNghiems()
    {
        var cauHoiTracNghiems = await _cauHoiTracNghiemService.GetAllCauHoiTracNghiemsAsync();
        return Ok(cauHoiTracNghiems);
    }

    /// <summary>
    /// Get a specific multiple choice question by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CauHoiTracNghiem>> GetCauHoiTracNghiemById(int id)
    {
        var cauHoiTracNghiem = await _cauHoiTracNghiemService.GetCauHoiTracNghiemByIdAsync(id);
        
        if (cauHoiTracNghiem == null)
        {
            return NotFound(new { message = $"Multiple choice question with ID {id} not found." });
        }
        
        return Ok(cauHoiTracNghiem);
    }

    /// <summary>
    /// Create a new multiple choice question
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CauHoiTracNghiem>> CreateCauHoiTracNghiem([FromBody] CauHoiTracNghiem cauHoiTracNghiem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdCauHoiTracNghiem = await _cauHoiTracNghiemService.CreateCauHoiTracNghiemAsync(cauHoiTracNghiem);
            return CreatedAtAction(
                nameof(GetCauHoiTracNghiemById), 
                new { id = createdCauHoiTracNghiem.MaCauHoi }, 
                createdCauHoiTracNghiem
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing multiple choice question
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCauHoiTracNghiem(int id, [FromBody] CauHoiTracNghiem cauHoiTracNghiem)
    {
        if (id != cauHoiTracNghiem.MaCauHoi)
        {
            return BadRequest(new { message = "ID mismatch between route and body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _cauHoiTracNghiemService.UpdateCauHoiTracNghiemAsync(cauHoiTracNghiem);
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
    /// Delete a multiple choice question
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCauHoiTracNghiem(int id)
    {
        try
        {
            await _cauHoiTracNghiemService.DeleteCauHoiTracNghiemAsync(id);
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

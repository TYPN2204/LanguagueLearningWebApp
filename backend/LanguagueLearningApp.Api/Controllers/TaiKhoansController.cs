using Microsoft.AspNetCore.Mvc;
using LanguagueLearningApp.Api.Models;
using LanguagueLearningApp.Api.Services.Interfaces;

namespace LanguagueLearningApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaiKhoansController : ControllerBase
{
    private readonly ITaiKhoanService _taiKhoanService;

    public TaiKhoansController(ITaiKhoanService taiKhoanService)
    {
        _taiKhoanService = taiKhoanService;
    }

    /// <summary>
    /// Get all accounts
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetAllTaiKhoans()
    {
        var taiKhoans = await _taiKhoanService.GetAllTaiKhoansAsync();
        return Ok(taiKhoans);
    }

    /// <summary>
    /// Get a specific account by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaiKhoan>> GetTaiKhoanById(int id)
    {
        var taiKhoan = await _taiKhoanService.GetTaiKhoanByIdAsync(id);
        
        if (taiKhoan == null)
        {
            return NotFound(new { message = $"Account with ID {id} not found." });
        }
        
        return Ok(taiKhoan);
    }

    /// <summary>
    /// Create a new account
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TaiKhoan>> CreateTaiKhoan([FromBody] TaiKhoan taiKhoan)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdTaiKhoan = await _taiKhoanService.CreateTaiKhoanAsync(taiKhoan);
            return CreatedAtAction(
                nameof(GetTaiKhoanById), 
                new { id = createdTaiKhoan.MaTaiKhoan }, 
                createdTaiKhoan
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Update an existing account
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTaiKhoan(int id, [FromBody] TaiKhoan taiKhoan)
    {
        if (id != taiKhoan.MaTaiKhoan)
        {
            return BadRequest(new { message = "ID mismatch between route and body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _taiKhoanService.UpdateTaiKhoanAsync(taiKhoan);
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
    /// Delete an account
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTaiKhoan(int id)
    {
        try
        {
            await _taiKhoanService.DeleteTaiKhoanAsync(id);
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

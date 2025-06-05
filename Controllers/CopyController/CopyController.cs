using CC_API.Domain.DTOs.Copy;
using CC_API.Domain.Entities.Copy;
using CC_API.Domain.Interfaces.ICopy;
using CC_API.Domain.Services.SCopy;
using Microsoft.AspNetCore.Mvc;

namespace CC_API.Controllers.CopyController;

[Route("cc_api/[controller]")]
[ApiController]
public class CopyController(ICopy copyService) : ControllerBase
{
    private readonly ICopy _copyService = copyService;

    /// <summary>
    /// Records the cost values per page linked to the year of validity.
    /// </summary>
    /// <param name="copy">DTO containing the date and year information only for data visualization.</param>
    /// <returns>status of the operation with the specific HTTP verb code.</returns>
    [HttpPost("register_cost")]
    [ProducesResponseType(typeof(Copy), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CostPerPage([FromBody] CopyDTO copy)
    {
        try
        {
            var entity = await _copyService.Register_CPP(copy);
            return CreatedAtAction(nameof(CostPerPage), new { id = entity.Id }, entity);
        }
        catch (BusinessException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    /// <summary>
    /// Returns all registered copy costs.
    /// </summary>
    [HttpGet("show_values")]
    [ProducesResponseType(typeof(List<Copy>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ShowValues()
    {
        try
        {
            List<Copy> copies = await _copyService.Show_CPP();
            return Ok(copies);
        }
        catch(BusinessException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
    }

    /// <summary>
    /// Updates the cost per page for a specific copy record.
    /// </summary>
    /// <param name="id">The unique identifier of the copy record to update.</param>
    /// <param name="copy">DTO containing the new year and cost per page values.</param>
    /// <returns>
    /// Returns the updated <see cref="Copy"/> entity if successful.<br/>
    /// Returns 400 if the input is invalid.<br/>
    /// Returns 404 if the record is not found.<br/>
    /// </returns>
    [HttpPut("edit_cost/{id}")]
    [ProducesResponseType(typeof(Copy), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCosts(Guid id, [FromBody] CopyDTO copy)
    {
        try
        {
            var entity = await _copyService.Update_CPP(id, copy);
            return Ok(entity);
        }
        catch (BusinessException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a specific copy cost record by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the copy record to delete.</param>
    /// <returns>
    /// Returns 204 No Content if the deletion is successful.
    /// Returns 404 if the record is not found.
    /// </returns>
    [HttpDelete("delete_cost/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCost(Guid id)
    {
        try
        {
            await _copyService.Delete_CPP(id);
            return NoContent();
        }
        catch (BusinessException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        
    }
}
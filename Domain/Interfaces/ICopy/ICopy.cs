using CC_API.Domain.DTOs.Copy;
using CC_API.Domain.Entities.Copy;
using CC_API.Domain.Services.SCopy;

namespace CC_API.Domain.Interfaces.ICopy;

/// <summary>
/// Defines the contract for copy cost management services.
/// </summary>
public interface ICopy
{
    /// <summary>
    /// Registers a new copy cost for a given year.
    /// </summary>
    /// <param name="copy">DTO containing the year and cost per page information.</param>
    /// <returns>The created <see cref="Copy"/> entity with its generated identifier.</returns>
    /// <exception cref="BusinessException">
    /// Thrown when the input data is invalid or a cost for the specified year already exists.
    /// </exception>
    Task<Copy> Register_CPP(CopyDTO copy);

    /// <summary>
    /// Retrieves all registered copy costs.
    /// </summary>
    /// <returns>A list of <see cref="Copy"/> entities.</returns>
    /// <exception cref="BusinessException">
    /// Thrown when no copy costs are found.
    /// </exception>
    Task<List<Copy>> Show_CPP();

    /// <summary>
    /// Updates the cost per page for a specific copy record.
    /// </summary>
    /// <param name="id">The unique identifier of the copy record to update.</param>
    /// <param name="copy">DTO containing the new year and cost per page values.</param>
    /// <returns>The updated <see cref="Copy"/> entity.</returns>
    /// <exception cref="BusinessException">
    /// Thrown when the input data is invalid, the record is not found, or a conflict occurs.
    /// </exception>
    Task<Copy> Update_CPP(Guid id, CopyDTO copy);

    /// <summary>
    /// Deletes a specific copy cost record by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the copy record to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="BusinessException">
    /// Thrown when the record is not found.
    /// </exception>
    Task Delete_CPP(Guid id);
}
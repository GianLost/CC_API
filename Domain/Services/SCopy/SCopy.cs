using CC_API.Domain.DTOs.Copy;
using CC_API.Domain.Entities.Copy;
using CC_API.Domain.Interfaces.ICopy;
using CC_API.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CC_API.Domain.Services.SCopy;

/// <summary>
/// Exception thrown when a business rule is violated in copy cost operations.
/// </summary>
public class BusinessException(string message) : Exception(message) { }

/// <summary>
/// Service implementation for managing copy cost records.
/// </summary>
public class SCopy(DatabaseContext context) : ICopy
{
    private readonly DatabaseContext _context = context;

    /// <inheritdoc/>
    public async Task<Copy> Register_CPP(CopyDTO copy)
    {
        if (copy.Year < 2024)
            throw new BusinessException("O ano informado é inválido. Deve ser 2024 ou superior.");

        if (_context.Copies.Any(c => c.Year == copy.Year))
            throw new BusinessException($"Já existe um custo cadastrado para o ano {copy.Year}.");

        if (copy.CopyCost <= 0)
            throw new BusinessException("O custo por página deve ser maior que zero.");

        if (copy.CopyCost >= 10)
            throw new BusinessException("O custo por página informado é muito alto. Verifique o valor.");

        var entity = new Copy
        {
            Year = copy.Year,
            CopyCost = copy.CopyCost
        };

        await _context.Copies.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    /// <inheritdoc/>
    public async Task<List<Copy>> Show_CPP()
    {
        var copies = await _context.Copies.ToListAsync();

        if (copies == null || copies.Count == 0)
            throw new BusinessException("Nenhum valor de cópia cadastrado.");

        return copies;
    }

    /// <inheritdoc/>
    public async Task<Copy> Update_CPP(Guid id, CopyDTO copy)
    {
        if (copy.Year < 2024)
            throw new BusinessException("O ano informado é inválido. Deve ser 2024 ou superior.");

        if (copy.CopyCost <= 0)
            throw new BusinessException("O custo por página deve ser maior que zero.");

        if (copy.CopyCost >= 10)
            throw new BusinessException("O custo por página informado é muito alto. Verifique o valor.");

        var entity = await _context.Copies.FirstOrDefaultAsync(c => c.Id == id) ?? throw new BusinessException($"Nenhum custo encontrado para o id {id}.");

        if (_context.Copies.Any(c => c.Year == copy.Year && c.Id != id))
            throw new BusinessException($"Já existe um custo cadastrado para o ano {copy.Year}.");

        entity.Year = copy.Year;
        entity.CopyCost = copy.CopyCost;

        await _context.SaveChangesAsync();

        return entity;
    }

    /// <inheritdoc/>
    public async Task Delete_CPP(Guid id)
    {
        var entity = _context.Copies.FirstOrDefault(c => c.Id == id) ?? throw new BusinessException($"Custo de cópia com id {id} não encontrado.");

        _context.Copies.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
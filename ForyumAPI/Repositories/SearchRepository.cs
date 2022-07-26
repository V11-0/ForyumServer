using ApplicationCore.Models;
using Dapper;
using ForyumAPI.Models.DTO;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ForyumAPI.Repositories;

public interface ISearchRepository
{
    Task<IEnumerable<SearchCompletion>> Search(string value);
}

public class SearchRepository : ISearchRepository
{
    private readonly AppDbContext _context;

    public SearchRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SearchCompletion>> Search(string value)
    {
        var connection = _context.Database.GetDbConnection();

        var command = new CommandDefinition(
            @"SELECT Id 'id', Username 'name', 0 'type' FROM Users WHERE Username LIKE CONCAT('%', @value, '%')
            UNION
            SELECT Id 'id', Name 'name', 1 'type' FROM Communities WHERE Name LIKE CONCAT('%', @value, '%')",
            new { value }
        );

        return await connection.QueryAsync<SearchCompletion>(command);
    }
}
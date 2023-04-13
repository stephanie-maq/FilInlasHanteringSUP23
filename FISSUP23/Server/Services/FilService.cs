using FISSUP23.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FISSUP23.Server.Services;

public class FilService : IFilService
{
    private readonly SsisGenericReadContext _context;

    public FilService(SsisGenericReadContext context)
    {
        _context = context;
    }

    public async Task<List<Fil>> GetFiler()
    {
        return await _context.Fils.ToListAsync();
    }

    public Task<Fil> GetByID(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Fil fil)
    {
        _context.Fils.Add(fil);
        await _context.SaveChangesAsync();
    }

    public Task Update(int id, Fil fil)
    {
        throw new NotImplementedException();
    }

    public Task Delete(List<string> ids)
    {
        throw new NotImplementedException();
    }

    public Task<List<Fil>> Get()
    {
        throw new NotImplementedException();
    }
}
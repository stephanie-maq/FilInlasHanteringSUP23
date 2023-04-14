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

    public async Task<List<Fil>> GetByID(int id)
    {
        var fils = await _context.Fils
            .Include(x => x.FilDatatyps)
            .Include(x => x.Kolumns)
            .Include(x => x.Inlasnings)
            .Include(x => x.Tabells)
            .Where(x => x.FilKollektionId == id)
            .ToListAsync();
        return fils;
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

    public async Task<List<Fil>> Get()
    {
        return await _context.Fils.ToListAsync();
    }
}
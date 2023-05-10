using FISSUP23.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FISSUP23.Server.Services;

public class ProcessdataService : IProcessdataService
{
    private readonly SsisGenericReadContext _context;

    public ProcessdataService(SsisGenericReadContext context)
    {
        _context = context;
    }
    
    public async Task<List<Inlasning>> GetInlasningar()
    {
        return await _context.Inlasnings.Include(x => x.Kolumns)
            .Include(y => y.ErrorLog)
            .ToListAsync();
    }
}
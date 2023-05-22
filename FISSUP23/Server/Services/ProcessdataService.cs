using FISSUP23.Database.Models;
using Microsoft.EntityFrameworkCore;
using Overforing = FISSUP23.Client.Pages.Overforing;

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
        return await _context.Inlasnings
            .Include(p=>p.Kolumns)
            .Include(u=>u.Fil)
            .ThenInclude(b=>b.FilDatatyps)
            .Include(y=>y.Tabells)
            .ToListAsync();
    }
}
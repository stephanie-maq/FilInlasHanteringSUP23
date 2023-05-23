using FISSUP23.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FISSUP23.Server.Services;

public class KolumnService : IKolumnService
{
    private readonly SsisGenericReadContext _context;

    public KolumnService(SsisGenericReadContext context)
    {
        _context = context;
    }
    
    public async Task<List<Kolumn>> GetKolumner()
    {
        return await _context.Kolumns
            .ToListAsync();
    }
}
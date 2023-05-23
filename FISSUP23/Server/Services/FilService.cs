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

    public async Task<Fil> GetById(int id)
    {
       var fils= await _context.Fils.Where(x => x.Id == id)
           .Include(y=>y.Kolumns)
           .Include(r=>r.Tabells)
           .Include(x => x.FilDatatyps)
           .Include(x => x.Inlasnings)
           .ToListAsync();
       return fils.FirstOrDefault();
    }

    public async Task Add(Fil fil)
    {
        _context.Entry(fil).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task AddFilDatatype(FilDatatyp filDatatyp)
    {
        _context.Entry(filDatatyp).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    private static string IsEmpty(string s1, string s2)
    {
        if (string.IsNullOrEmpty(s1) || string.IsNullOrWhiteSpace(s1))
        {
            return s2;
        }

        return s1;
    }
    
    public async Task Update(int id, Fil fil)
    {
        var existing = await _context.Fils.FirstOrDefaultAsync(n => n.Id == id);

        if (existing == null)
        {
            throw new Exception("Id not found");
        }

        
        existing.Beskrivning = fil.Beskrivning ?? existing.Beskrivning;
        existing.Namn = IsEmpty(fil.Namn, existing.Namn);
        existing.Sort = fil.Sort ?? existing.Sort;
        existing.HarKolumnamn = fil.HarKolumnamn ?? existing.HarKolumnamn;
        existing.KolumnSeparator = IsEmpty(fil.KolumnSeparator, existing.KolumnSeparator);
        existing.MatchMonster = IsEmpty(fil.MatchMonster, existing.MatchMonster);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(List<string> toDelete)
    {
        var fils = await GetFiler();

        fils
            .FindAll(o => toDelete.Contains(o.Id.ToString()))
            .ForEach(x => _context.Remove(x));

        await _context.SaveChangesAsync();
    }

    public async Task<List<Fil>> GetFiler()
    {
        return await _context.Fils
            .Include(x => x.FilDatatyps)
            .ThenInclude(y => y.Datatyp)
            .ToListAsync();
    }

    public async Task<List<Filtyp>> GetFilTyper()
    {
        return await _context.Filtyps.ToListAsync();
    }

    public async Task<List<Datatyp>> GetDataTyper()
    {
        return await _context.Datatyps
            .ToListAsync();
    }
}
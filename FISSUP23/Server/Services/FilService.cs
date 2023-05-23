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

    public Task Update(int id, Fil fil)
    {
        throw new NotImplementedException();
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
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

    public async Task<List<Fil>> GetById(int id)
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
        _context.Entry(fil).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task AddFilDatatype(FilDatatyp filDatatyp)
    {
        switch (filDatatyp.DatatypId)
        {
            case 1:
            {
                var datatyps = await _context.FilDatatyps.Where(x => x.Datatyp.Namn == "int").ToListAsync();
                var realId = datatyps.First().DatatypId;
                filDatatyp.DatatypId = realId;
                break;
            }
            case 2:
            {
                var datatyps = await _context.FilDatatyps.Where(x => x.Datatyp.Namn == "varchar").ToListAsync();
                var realId = datatyps.First().DatatypId;
                filDatatyp.DatatypId = realId;
                break;
            }
        }
        _context.Entry(filDatatyp).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public Task Update(int id, Fil fil)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(List<string> toDelete)
    {
        var fils = await Get();

        fils
            .FindAll(o => toDelete.Contains(o.Id.ToString()))
            .ForEach(x => _context.Remove(x));

        await _context.SaveChangesAsync();
    }

    public async Task<List<Fil>> Get()
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
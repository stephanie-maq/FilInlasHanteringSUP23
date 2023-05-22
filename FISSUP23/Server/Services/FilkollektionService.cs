using FISSUP23.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FISSUP23.Server.Services
{
    public class FilkollektionService : IFilkollektionService
    {
        private SsisGenericReadContext _context;

        public FilkollektionService(SsisGenericReadContext context)
        {
            _context = context;
        }

        public async Task<List<FilKollektion>> GetFilkollektioner()
        {
            return await _context.FilKollektions.Include(x => x.Fils)
                .ToListAsync();
        }

        public async Task<List<FilKollektion>> GetByOverforingID(int id)
        {
            var filKollektions = await _context.FilKollektions.Include(x => x.Fils).Where(x => x.OverforingId == id).ToListAsync();
            return filKollektions;
        }

        public async Task<FilKollektion> GetById(int id)
        {
            if (_context.FilKollektions == null)
            {
                throw new Exception("Id not found");
            }
        
            var filKollektion = await _context.FilKollektions
                .Include(x=>x.Fils)
                .ThenInclude(y=>y.Kolumns)
                .FirstOrDefaultAsync(n => n.Id == id);
        
            if (filKollektion == null)
            {
                throw new Exception("Filkollektion does not exist");
            }
        
            return filKollektion;
        }
        public async Task Add(FilKollektion filkollektion)
        {
            _context.Entry(filkollektion).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, FilKollektion filkollektion)
        {
            var existing = await _context.FilKollektions
                .FirstOrDefaultAsync(n => n.Id == id);

            if (existing == null)
            {
                throw new Exception("Id not found");
            }
            
            existing.Namn = filkollektion.Namn;
            existing.Andelse = filkollektion.Andelse;
            existing.MatchMonster = filkollektion.MatchMonster;
            existing.Beskrivning = filkollektion.Beskrivning ?? existing.Beskrivning;
            existing.OverforingId = filkollektion.OverforingId;
            existing.FilTypId = filkollektion.FilTypId;
            existing.FolderRoot = filkollektion.FolderRoot;
            existing.FolderArkiv = filkollektion.FolderArkiv;
            existing.FolderNyFil = filkollektion.FolderNyFil;
            existing.FolderFelaktigFil = filkollektion.FolderFelaktigFil;
            existing.FilTypId = filkollektion.FilTypId;
            existing.Fils = filkollektion.Fils ?? existing.Fils;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(List<string> toDelete)
        {
            var filkollektions = await Get();

            filkollektions
                .FindAll(o => toDelete.Contains(o.Id.ToString()))
                .ForEach(x => _context.Remove(x));

            await _context.SaveChangesAsync();
        }

        public async Task<List<FilKollektion>> Get()
        {
            return await _context.FilKollektions
                .Include(x => x.Fils)
                .ThenInclude(f=>f.FilDatatyps)
                .ToListAsync();
        }
    }
}
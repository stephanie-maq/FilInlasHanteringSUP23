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
            return await _context.FilKollektions.ToListAsync();
        }

        public async Task<List<FilKollektion>> GetByID(int id)
        {
            var filKollektions = await _context.FilKollektions.Include(x => x.Fils).Where(x => x.OverforingId == id).ToListAsync();
            return filKollektions;
        }

        public async Task Add(FilKollektion _Filkollektion)
        {
            _context.FilKollektions.Add(_Filkollektion);
            await _context.SaveChangesAsync();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
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
                .ToListAsync();
        }
    }
}
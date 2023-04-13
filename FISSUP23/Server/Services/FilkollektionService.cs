using FISSUP23.Database.Models;
using FISSUP23.Server.ApiModels;
using FISSUP23.Server.ApiModels.Extension;
using FISSUP23.Server.Services.Interface;
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
            var filKollektions = await _context.FilKollektions.Where(x => x.OverforingId == id).ToListAsync();
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

        public Task Delete(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FilKollektion>> Get()
        {
            return await _context.FilKollektions
                .Include(x => x.Fils)
                .ToListAsync();        }
    }
}
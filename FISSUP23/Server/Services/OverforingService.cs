using FISSUP23.Database.Models;
using FISSUP23.Server.Services.Interface;
using Microsoft.EntityFrameworkCore;


namespace FISSUP23.Server.Services
{
    public class OverforingService : IOverforingService

    {
        private readonly SsisGenericReadContext _context;

        public OverforingService(SsisGenericReadContext context)
        {
            _context = context;
        }

        public async Task Add(Overforing overforing)
        {
            _context.Overforings.Add(overforing);
            await _context.SaveChangesAsync();
        }
        
        
        public async Task Delete(List<string> toDelete)
        {
            var overfors = await Get();

            overfors
                .FindAll(o => toDelete.Contains(o.Id.ToString()))
                .ForEach(x => _context.Remove(x));

            await _context.SaveChangesAsync();
        }
        

        public async Task<Overforing> GetByID(int id)
        {
            if (_context.Overforings == null)
            {
                throw new Exception("Id not found");
            }

            var overforing = await _context.Overforings.FirstOrDefaultAsync(n => n.Id == id);

            if (overforing == null)
            {
                throw new Exception("Overföring does not exist");
            }

            return overforing;
        }
        

        public async Task<List<Overforing>> GetOverforingar()
        {
            return await _context.Overforings.ToListAsync();

        }

        public async Task<List<Overforing>> Get()
        {
            return await _context.Overforings
                .Include(x => x.FilKollektions)
                .ThenInclude(f => f.Fils)
                .ToListAsync();
        }

        public async Task Update(int id, Overforing overforing)
        {
            var existing = await _context.Overforings.FirstOrDefaultAsync(n => n.Id == id);

            if (existing == null)
            {
                throw new Exception("Id not found");
            }

            existing.Namn = overforing.Namn ?? existing.Namn;
            existing.SystemNamn = overforing.SystemNamn ?? existing.SystemNamn;
            existing.Beskrivning = overforing.Beskrivning ?? existing.Beskrivning;
            await _context.SaveChangesAsync();
        }
        


        private bool OverforingExists(int id)
        {
            return (_context.Overforings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
using FISSUP23.Database.Models;
using FISSUP23.Server.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace FISSUP23.Server.Services
{
    
        public class OverforingService : IOverforingService

        {
        private readonly SsisGenericReadContext _context;

        public OverforingService(SsisGenericReadContext context)
            {
                _context = context;
            }
            public async Task Add(Overforing _overforing)
            {
                _context.Overforings.Add(_overforing);
                _context.SaveChangesAsync();
            }

            public async Task Delete(int id)
            {
            throw new NotImplementedException();
          }

        private void NoContent()
        {
            throw new NotImplementedException();
        }

        public async Task<Overforing> GetByID(int id)
            {
            if (_context.Overforings == null)
            {
                return NotFound();
            }
            var overforing = await _context.Overforings.FirstOrDefaultAsync(n => n.Id == id);

            if (overforing == null)
            {
                return NotFound();
            }

            return overforing;
       
            }

        private Overforing NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Overforing>> GetOverforingar()
            {
                var result = await _context.Overforings.ToListAsync();
                return result;
            }

        public async Task<Overforing> Update(int id, Overforing newOverforing)
        {
           throw new NotImplementedException();
        }

        }
    
}


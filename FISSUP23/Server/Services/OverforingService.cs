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
                .ForEach(x=>_context.Remove(x));
            
            await _context.SaveChangesAsync();
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

        public async Task<List<Overforing>> Get()
        {
            return await _context.Overforings
                .Include(x => x.FilKollektions)
                .ToListAsync();
        }

        public async Task Update(int id)
        {
            var over = GetOverforingar();
            if (id != over.Id)
            {
                throw new Exception("Id not found");
            }

            _context.Entry(over).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();


            //if (id != newOverforing.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(newOverforing).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OverforingExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return 
        }

        private Database.Models.Overforing BadRequest()
        {
            throw new NotImplementedException();
        }


        private bool OverforingExists(int id)
        {
            return (_context.Overforings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
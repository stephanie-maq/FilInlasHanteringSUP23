using FISSUP23.Database.Models;
using FISSUP23.Server.ApiModels;
using FISSUP23.Server.ApiModels.Extension;
using FISSUP23.Server.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;




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
            await _context.SaveChangesAsync();
        }

        public async Task Delete(List<string> toDelete)
        {
            var overfors = await Get();

            var toDelete2 = overfors
            .FindAll(o => toDelete.Contains(o.Id.ToString()))
            .Select(o => o.ToDb());

            foreach (var td in toDelete2)
            {
                _context.Remove(td);
            }

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

        public async Task<List<ApiOverforing>> Get()
        {
            List<ApiOverforing> ApiOverforingar = new List<ApiOverforing>();

            var dbOverforingar = await _context.Overforings.AsNoTracking().ToListAsync();
            foreach (var overforing in dbOverforingar)
            {
                var filkollektionService = new FilkollektionService(_context);

                var Apifilkollektioner = await filkollektionService.GetByOverforingId(overforing.Id);



                ApiOverforingar.Add(overforing.ToApi(Apifilkollektioner));
            }

            return ApiOverforingar;
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

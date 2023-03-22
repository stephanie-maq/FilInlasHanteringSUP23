using FISSUP23.Database.Models;
using FISSUP23.Server.ApiModels;
using FISSUP23.Server.ApiModels.Extension;
using FISSUP23.Server.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FISSUP23.Server.Services
{
    public class FilkollektionService : IFilkollektionService
    {
        private readonly SsisGenericReadContext _context;

        public FilkollektionService(SsisGenericReadContext context)
        {
            _context = context;
        }

        public Task Add(ApiFilkollektion apiFilkollektion)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApiFilkollektion>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ApiFilkollektion> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApiFilkollektion>> GetByOverforingId(int id)
        {
            List<ApiFilkollektion> Apifilkollektioner = new List<ApiFilkollektion>();
            var dbFilkollektioner = await _context.FilKollektions.Where(x => x.OverforingId == id).ToListAsync();

            if (dbFilkollektioner != null)
            {
                foreach (var filkollektion in dbFilkollektioner)
                {
                    Apifilkollektioner.Add(filkollektion.ToApi());
                }
            }

            return Apifilkollektioner;
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}

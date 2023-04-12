using FISSUP23.Database.Models;
using FISSUP23.Server.ApiModels;
using FISSUP23.Server.ApiModels.Extension;
using FISSUP23.Server.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FISSUP23.Server.Services
{
    public class FilkollektionService : IFilkollektionService
    {
        public Task<List<FilKollektion>> GetFilkollektioner()
        {
            throw new NotImplementedException();
        }

        public Task<FilKollektion> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task Add(FilKollektion _Filkollektion)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<FilKollektion>> Get()
        {
            throw new NotImplementedException();
        }
    }
}

using FISSUP23.Database.Models;
using FISSUP23.Server.ApiModels;

namespace FISSUP23.Server.Services.Interface
{
    public interface IFilkollektionService
    {
            Task<List<ApiFilkollektion>> Get();
        Task<List<ApiFilkollektion>> GetByOverforingId(int id);
        Task<ApiFilkollektion> GetByID(int id);
            Task Add(ApiFilkollektion apiFilkollektion);
            Task Update(int id);
            Task Delete(int id);


    }
}

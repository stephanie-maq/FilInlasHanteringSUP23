using FISSUP23.Server.ApiModels;

namespace FISSUP23.Server.Services
{
    public interface IFilkollektionService
    {
        Task<List<ApiFilkollektion>> Get();
        Task<List<ApiFilkollektion>> GetByOverforingId(int id);
        Task<ApiFilkollektion> GetById(int id);
        Task Add(ApiFilkollektion apiFilkollektion);
        Task Update(int id);
        Task Delete(int id);
    }
}
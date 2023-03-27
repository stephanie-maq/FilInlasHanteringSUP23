using FISSUP23.Database.Models;
using FISSUP23.Server.ApiModels;

namespace FISSUP23.Server.Services.Interface
{
    public interface IOverforingService
    {
        Task<List<Overforing>> GetOverforingar();
        Task<Overforing> GetByID(int id);
        Task Add(Overforing _overforing);
        Task Update(int id);

        Task Delete(List<string> ids);

        Task<List<ApiOverforing>> Get();
    }
}

using FISSUP23.Database.Models;
using FISSUP23.Server.ApiModels;

namespace FISSUP23.Server.Services.Interface
{
    public interface IOverforingService
    {
        Task<Overforing> GetByID(int id);
        Task Add(Overforing overforing);

        Task Update(int id, Overforing overforing);

        Task Delete(List<string> ids);

        Task<List<Overforing>> GetOverforingar();
    }
}

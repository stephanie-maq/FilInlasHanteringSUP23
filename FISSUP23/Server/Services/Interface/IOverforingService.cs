using FISSUP23.Database.Models;


namespace FISSUP23.Server.Services.Interface
{
    public interface IOverforingService
    {
            Task<List<Overforing>> GetOverforingar();
            Task<Overforing> GetByID(int id);
            Task Add(Overforing _overforing);
            Task<Overforing> Update(int id, Overforing newOverforing);

            Task Delete(int id);
    }
}

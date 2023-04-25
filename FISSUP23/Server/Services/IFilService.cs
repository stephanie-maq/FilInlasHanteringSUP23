using FISSUP23.Database.Models;

namespace FISSUP23.Server.Services;

public interface IFilService
{
    Task<List<Fil>> GetFiler();
    Task<List<FilDatatyp>> GetFilDataTyper();
    Task<List<Fil>> GetByID(int id);
    Task Add(Fil Fil);

    Task Update(int id, Fil fil);

    Task Delete(List<string> ids);

    Task<List<Fil>> Get();
    Task<List<Filtyp>> GetFilTyper();
}
using FISSUP23.Database.Models;

namespace FISSUP23.Server.Services;

public interface IFilService
{
    Task<List<Datatyp>> GetDataTyper();
    Task<Fil> GetById(int id);
    Task Add(Fil fil);
    Task AddFilDatatype(FilDatatyp filDatatyp);
    Task Delete(List<string> ids);
    Task<List<Fil>> GetFiler();
    Task<List<Filtyp>> GetFilTyper();
    Task Update(int filId, Fil fil);
}
using FISSUP23.Database.Models;

namespace FISSUP23.Server.Services;

public interface IFilService
{
    Task<List<Datatyp>> GetDataTyper();
    Task<List<Fil>> GetById(int id);
    Task Add(Fil Fil);
    Task AddFilDatatype(FilDatatyp filDatatyp);
    Task Delete(List<string> ids);

    Task<List<Fil>> Get();
    Task<List<Filtyp>> GetFilTyper();
}
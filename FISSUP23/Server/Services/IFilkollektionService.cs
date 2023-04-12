using FISSUP23.Database.Models;

namespace FISSUP23.Server.Services;

public interface IFilkollektionService
{
    Task<List<FilKollektion>> GetFilkollektioner();
    Task<List<FilKollektion>> GetByID(int id);
    Task Add(FilKollektion _Filkollektion);
    Task Update(int id);

    Task Delete(List<string> ids);

    Task<List<FilKollektion>> Get();
}
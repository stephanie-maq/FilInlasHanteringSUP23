using FISSUP23.Database.Models;

namespace FISSUP23.Server.Services;

public interface IFilkollektionService
{
    Task<List<FilKollektion>> GetFilkollektioner();
    //Task<FilKollektion> GetByID(int id);
    Task<List<FilKollektion>> GetByOverforingID(int id);
    Task Add(FilKollektion filkollektion);
    Task Update(int id);

    Task Delete(List<string> ids);

    Task<List<FilKollektion>> Get();
}
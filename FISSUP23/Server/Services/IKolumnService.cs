using FISSUP23.Database.Models;

namespace FISSUP23.Server.Services;

public interface IKolumnService
{
    Task<List<Kolumn>> GetKolumner();
}
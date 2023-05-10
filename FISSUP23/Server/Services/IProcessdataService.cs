using FISSUP23.Database.Models;

namespace FISSUP23.Server.Services;

public interface IProcessdataService
{
    Task<List<Inlasning>> GetInlasningar();
}
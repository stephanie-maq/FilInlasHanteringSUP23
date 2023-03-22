using FISSUP23.Database.Models;

namespace FISSUP23.Server.ApiModels
{
    public class ApiFilkollektion
    {
        public int Id { get; set; }

        public string Namn { get; set; } = null!;

        public string Andelse { get; set; } = null!;

        public string MatchMonster { get; set; } = null!;

        public string? Beskrivning { get; set; }

        public int OverforingId { get; set; }

        public int FilTypId { get; set; }

        public string FolderRoot { get; set; } = null!;

        public string FolderArkiv { get; set; } = null!;

        public string FolderNyFil { get; set; } = null!;

        public string FolderFelaktigFil { get; set; } = null!;

    }
}

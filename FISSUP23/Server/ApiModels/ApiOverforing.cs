namespace FISSUP23.Server.ApiModels
{
    public class ApiOverforing
    {
        public int Id { get; set; }

        public string Namn { get; set; } = null!;

        public string SystemNamn { get; set; } = null!;

        public string? Beskrivning { get; set; }

        public List<ApiFilkollektion> FilKollektions { get; set; }

        public int AntalFilkollektioner { get; set; }
    }
}

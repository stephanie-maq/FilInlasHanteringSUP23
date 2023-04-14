using FISSUP23.Database.Models;

namespace FISSUP23.Client.ViewModels;

public class FilViewModel
{
    public bool isChecked { get; set; }

    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public string MatchMonster { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public int? Sort { get; set; }
    
    public string KolumnSeparator { get; set; } = null!;

    public short HarKolumnamn { get; set; }

    public int AntalFilDatatyp { get; set; }
    
    
}
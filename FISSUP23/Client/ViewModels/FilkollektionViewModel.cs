using FISSUP23.Database.Models;

namespace FISSUP23.Client.ViewModels;

public class FilkollektionViewModel : IViewModels
{
    public bool isChecked { get; set; }
    
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public string Andelse { get; set; } = null!;

    public string MatchMonster { get; set; } = null!;

    public string? Beskrivning { get; set; }
    
    public int FilTypId { get; set; }

    public string FolderRoot { get; set; } = null!;

    public string FolderArkiv { get; set; } = null!;

    public string FolderNyFil { get; set; } = null!;

    public string FolderFelaktigFil { get; set; } = null!;

    public Filtyp FilTyp { get; set; } = null!;

    public List<Fil> Fils { get; set; }

    public int AntalFiler { get; set; }

    public Overforing Overforing { get; set; } = null!;
}
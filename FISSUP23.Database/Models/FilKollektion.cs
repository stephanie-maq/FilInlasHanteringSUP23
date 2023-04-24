using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FISSUP23.Database.Models;

public partial class FilKollektion
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
    
    public virtual ICollection<Fil> Fils { get; set; } = new List<Fil>();
    
}

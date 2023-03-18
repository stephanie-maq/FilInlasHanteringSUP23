using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Filtyp
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public string Andelse { get; set; } = null!;

    public string PunktAndelse { get; set; } = null!;

    public virtual ICollection<FilKollektion> FilKollektions { get; } = new List<FilKollektion>();
}

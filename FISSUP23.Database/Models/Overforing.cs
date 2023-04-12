using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Overforing
{
    public int Id { get; set; }

    public string? Namn { get; set; } = null!;

    public string? SystemNamn { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public virtual ICollection<FilKollektion> FilKollektions { get; set; } = new List<FilKollektion>();
}

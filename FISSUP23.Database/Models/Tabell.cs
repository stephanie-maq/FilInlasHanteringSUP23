using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Tabell
{
    public int Id { get; set; }

    public string Schema { get; set; } = null!;

    public string Namn { get; set; } = null!;

    public string VySchema { get; set; } = null!;

    public string VyPrefix { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public int FilId { get; set; }

    public string TabellNamn { get; set; } = null!;

    public string VyNamn { get; set; } = null!;

    public string VyNamnLookup { get; set; } = null!;

    public int? SkapadInlasningId { get; set; }

    public DateTime? Modifierad { get; set; }

    public virtual Fil Fil { get; set; } = null!;

    public virtual Inlasning? SkapadInlasning { get; set; }
}

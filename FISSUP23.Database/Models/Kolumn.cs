using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Kolumn
{
    public int Id { get; set; }

    public string InNamn { get; set; } = null!;

    public string? UtNamn { get; set; }

    public short? NyKolumn { get; set; }

    public int? Sort { get; set; }

    public int FilId { get; set; }

    public int? InlasningId { get; set; }

    public virtual Inlasning? Inlasning { get; set; }

    public virtual ICollection<KolumnDatatyp> KolumnDatatyps { get; } = new List<KolumnDatatyp>();

    public virtual ICollection<LookupKolumn> LookupKolumns { get; } = new List<LookupKolumn>();
}

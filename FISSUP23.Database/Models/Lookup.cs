using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Lookup
{
    public int Id { get; set; }

    public int FilId { get; set; }

    public int LookupTypId { get; set; }

    public virtual Fil Fil { get; set; } = null!;

    public virtual ICollection<LookupKolumn> LookupKolumns { get; } = new List<LookupKolumn>();

    public virtual LookupTyp LookupTyp { get; set; } = null!;
}

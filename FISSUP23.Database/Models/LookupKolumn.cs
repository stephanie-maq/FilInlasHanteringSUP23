using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class LookupKolumn
{
    public int Id { get; set; }

    public int LookupId { get; set; }

    public int KolumnId { get; set; }

    public virtual Kolumn Kolumn { get; set; } = null!;

    public virtual Lookup Lookup { get; set; } = null!;
}

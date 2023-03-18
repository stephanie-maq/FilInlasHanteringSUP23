using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class LookupTyp
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public virtual ICollection<Lookup> Lookups { get; } = new List<Lookup>();
}

using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class KolumnDatatyp
{
    public int Id { get; set; }

    public int KolumnId { get; set; }

    public int DatatypId { get; set; }

    public int? Length { get; set; }

    public int? Precision { get; set; }

    public int? Scale { get; set; }

    public short? IsNullable { get; set; }

    public virtual Datatyp Datatyp { get; set; } = null!;

    public virtual Kolumn Kolumn { get; set; } = null!;
}

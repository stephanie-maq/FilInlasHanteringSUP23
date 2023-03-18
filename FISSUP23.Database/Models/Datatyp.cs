using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Datatyp
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public byte SystemTypeId { get; set; }

    public short MaxLength { get; set; }

    public byte Precision { get; set; }

    public byte Scale { get; set; }

    public bool? IsNullable { get; set; }

    public short? Fig1 { get; set; }

    public short? Fig2 { get; set; }

    public virtual ICollection<FilDatatyp> FilDatatyps { get; } = new List<FilDatatyp>();

    public virtual ICollection<KolumnDatatyp> KolumnDatatyps { get; } = new List<KolumnDatatyp>();
}

using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class VKolumnDatatyp
{
    public int KolumnId { get; set; }

    public string? KolumnNamn { get; set; }

    public string? Datatyp { get; set; }

    public int? Length { get; set; }

    public int? Precision { get; set; }

    public int? Scale { get; set; }

    public short? IsNullable { get; set; }

    public short? Fig1 { get; set; }

    public short? Fig2 { get; set; }
}

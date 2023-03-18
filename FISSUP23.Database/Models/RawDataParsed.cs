using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class RawDataParsed
{
    public int Id { get; set; }

    public int? RawDataId { get; set; }

    public int KolumnId { get; set; }

    public string? RawDataParsed1 { get; set; }

    public int FilId { get; set; }

    public int InlasningId { get; set; }

    public virtual Fil Fil { get; set; } = null!;

    public virtual Inlasning Inlasning { get; set; } = null!;
}

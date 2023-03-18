using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class RawDatum
{
    public int Id { get; set; }

    public string? RawData { get; set; }

    public int FilId { get; set; }

    public int InlasningId { get; set; }

    public virtual Fil Fil { get; set; } = null!;

    public virtual Inlasning Inlasning { get; set; } = null!;
}

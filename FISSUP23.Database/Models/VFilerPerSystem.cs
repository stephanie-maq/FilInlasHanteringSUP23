using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class VFilerPerSystem
{
    public string SystemNamn { get; set; } = null!;

    public int FilKollektionId { get; set; }

    public int FilId { get; set; }

    public string MatchMonster { get; set; } = null!;

    public string FilSpec { get; set; } = null!;

    public int? Sort { get; set; }
}

using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class VParsedDatum
{
    public int FilId { get; set; }

    public int TabellId { get; set; }

    public string TabellNamn { get; set; } = null!;

    public int KolumnId { get; set; }

    public string? KolumnNamn { get; set; }

    public int InlasningId { get; set; }

    public int? DataRadId { get; set; }

    public string? Data { get; set; }
}

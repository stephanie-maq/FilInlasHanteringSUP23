using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class VInlastaRaderStephaniesKurser
{
    public int InlasningId { get; set; }

    public DateTime DatumTid { get; set; }

    public string FilNamn { get; set; } = null!;

    public short? RaderadData { get; set; }

    public short? Omlasning { get; set; }

    public string TabellNamn { get; set; } = null!;

    public int? AntalRaderFil { get; set; }

    public int? AntalRaderTabell { get; set; }
}

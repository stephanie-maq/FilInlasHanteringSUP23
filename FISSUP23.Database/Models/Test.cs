using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Test
{
    public DateTime DatumTid { get; set; }

    public string SystemNamn { get; set; } = null!;
}

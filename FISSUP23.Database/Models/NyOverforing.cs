using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FISSUP23.Database.Models;

public partial class NyOverforing
{
    [Key]
    public string? Namn { get; set; }

    public string? SystemNamn { get; set; }

    public string? Beskrivning { get; set; }
}

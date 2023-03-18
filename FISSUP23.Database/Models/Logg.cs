using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Logg
{
    public int Id { get; set; }

    public DateTime Tid { get; set; }

    public int? OverforingId { get; set; }

    public int? FilkollektionId { get; set; }

    public int? FilId { get; set; }

    public int? InlasningId { get; set; }

    public string? SokFil { get; set; }

    public string? AktuellFil { get; set; }

    public string? Handelse { get; set; }

    public string? Loggtext { get; set; }
}

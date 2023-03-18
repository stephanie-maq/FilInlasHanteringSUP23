using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class ErrorLog
{
    public int Id { get; set; }

    public DateTime Tid { get; set; }

    public string? ErrorText { get; set; }

    public int? ErrorCode { get; set; }

    public int? InlasningId { get; set; }

    public virtual ICollection<Inlasning> Inlasnings { get; } = new List<Inlasning>();
}

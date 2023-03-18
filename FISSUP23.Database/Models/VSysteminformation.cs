using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class VSysteminformation
{
    public int OverforingId { get; set; }

    public string SystemNamn { get; set; } = null!;

    public int FilkollektionId { get; set; }

    public string Andelse { get; set; } = null!;

    public string MatchMonster { get; set; } = null!;

    public string FolderRoot { get; set; } = null!;

    public string FolderArkiv { get; set; } = null!;

    public string FolderNyFil { get; set; } = null!;

    public string FolderFelaktigFil { get; set; } = null!;
}

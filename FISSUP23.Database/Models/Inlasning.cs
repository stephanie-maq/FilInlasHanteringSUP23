using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Inlasning
{
    public int Id { get; set; }

    public int FilId { get; set; }

    public DateTime DatumTid { get; set; }

    public string FilNamn { get; set; } = null!;

    public int? AntalTillagdaKolumner { get; set; }

    public int? AntalRader { get; set; }

    public short? RaderadData { get; set; }

    public short? Omlasning { get; set; }

    public short? Dubblett { get; set; }

    public string? Namn { get; set; }

    public int? ErrorLogId { get; set; }

    public virtual ErrorLog? ErrorLog { get; set; }

    public virtual Fil Fil { get; set; } = null!;

    public virtual ICollection<Kolumn> Kolumns { get; } = new List<Kolumn>();

    public virtual ICollection<RawDatum> RawData { get; } = new List<RawDatum>();

    public virtual ICollection<RawDataKolumner> RawDataKolumners { get; } = new List<RawDataKolumner>();

    public virtual ICollection<RawDataParsed> RawDataParseds { get; } = new List<RawDataParsed>();

    public virtual ICollection<Tabell> Tabells { get; } = new List<Tabell>();
}

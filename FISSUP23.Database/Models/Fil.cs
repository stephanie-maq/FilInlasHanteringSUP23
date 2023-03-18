using System;
using System.Collections.Generic;

namespace FISSUP23.Database.Models;

public partial class Fil
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public string MatchMonster { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public int? Sort { get; set; }

    public int FilKollektionId { get; set; }

    public string KolumnSeparator { get; set; } = null!;

    public short HarKolumnamn { get; set; }

    public virtual ICollection<FilDatatyp> FilDatatyps { get; } = new List<FilDatatyp>();

    public virtual FilKollektion FilKollektion { get; set; } = null!;

    public virtual ICollection<Inlasning> Inlasnings { get; } = new List<Inlasning>();

    public virtual ICollection<Kolumn> Kolumns { get; } = new List<Kolumn>();

    public virtual ICollection<Lookup> Lookups { get; } = new List<Lookup>();

    public virtual ICollection<RawDatum> RawData { get; } = new List<RawDatum>();

    public virtual ICollection<RawDataKolumner> RawDataKolumners { get; } = new List<RawDataKolumner>();

    public virtual ICollection<RawDataParsed> RawDataParseds { get; } = new List<RawDataParsed>();

    public virtual ICollection<Tabell> Tabells { get; } = new List<Tabell>();
}

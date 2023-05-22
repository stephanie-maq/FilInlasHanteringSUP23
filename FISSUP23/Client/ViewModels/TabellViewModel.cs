using FISSUP23.Database.Models;

namespace FISSUP23.Client.ViewModels;

public class TabellViewModel : IViewModels
{
    public int Id { get; set; }

    public bool isChecked { get; set; }

    public string Schema { get; set; } = null!;

    public int FilId { get; set; }
    public string Namn { get; set; } = null!;

    public string VySchema { get; set; } = null!;

    public string VyPrefix { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public string TabellNamn { get; set; } = null!;

    public string VyNamn { get; set; } = null!;

    public string VyNamnLookup { get; set; } = null!;
    
    public DateTime? Modifierad { get; set; }

    public int? SkapadInlasningId { get; set; }
}
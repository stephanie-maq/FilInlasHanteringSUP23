namespace FISSUP23.Client.ViewModels;

public class KolumnViewModel : IViewModels
{
        public int Id { get; set; }

    public bool isChecked { get; set; }

    public string InNamn { get; set; }
    
    public string? UtNamn { get; set; }

    public int? Sort { get; set; }
}
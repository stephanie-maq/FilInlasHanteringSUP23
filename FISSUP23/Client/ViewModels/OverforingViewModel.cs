using FISSUP23.Database.Models;

namespace FISSUP23.Client.ViewModels
{
    public class OverforingViewModel : IViewModels
    {
        public bool isChecked { get; set; }

        public int Id { get; set; }

        public string Namn { get; set; } = null!;

        public string SystemNamn { get; set; } = null!;

        public string? Beskrivning { get; set; }

    }
}

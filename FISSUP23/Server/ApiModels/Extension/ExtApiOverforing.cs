using FISSUP23.Database.Models;

namespace FISSUP23.Server.ApiModels.Extension
{
    public static partial class Extension
    {
        public static ApiOverforing ToApi(this Overforing overforing, List<ApiFilkollektion> apiFilkollektion)
        {
            return new ApiOverforing
            {
                Id = overforing.Id,
                Namn = overforing.Namn,
                SystemNamn = overforing.SystemNamn,
                Beskrivning = overforing.Beskrivning,
                FilKollektions = apiFilkollektion,
                AntalFilkollektioner = apiFilkollektion.Count
            };
        }

        public static Overforing ToDb(this ApiOverforing apiOverforing)
        {
            return new Overforing
            {
                Id = apiOverforing.Id,
                Namn = apiOverforing.Namn,
                SystemNamn = apiOverforing.SystemNamn,
                Beskrivning = apiOverforing.Beskrivning
            };
        }
    }
}

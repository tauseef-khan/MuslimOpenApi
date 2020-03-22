namespace MuslimOpenApi.Models
{
    public class PrayerTime
    {
        public int ID { get; set; }

        public string Date { get; set; }

        public string FajrBegin { get; set; }

        public string FajrJamaah { get; set; }

        public string Sunrise { get; set; }

        public string ZuhrBegin { get; set; }

        public string ZuhrJamaah { get; set; }

        public string AsrMithl1 { get; set; }

        public string AsrMithl2 { get; set; }

        public string AsrJamaah { get; set; }

        public string MaghribBegin { get; set; }

        public string MaghribJamaah { get; set; }

        public string IshaBegin { get; set; }

        public string IshaJamaah { get; set; }
    }
}

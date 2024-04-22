using System;
using System.Text.Json.Serialization;

namespace Eurotorg_trainee.Models
{
    public class Dynamics
    {
        [JsonPropertyName("Cur_ID")]
        public int ID { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("Cur_OfficialRate")]
        public double OfficialRate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Appunto
    {
        public int IdAppunto { get; set; }
        public int IdRipetizione { get; set; }
        public string Note { get; set; }
        public int? Reps { get; set; }
        public decimal? Peso { get; set; }
        public DateTime Data { get; set; }

        public virtual Ripetizione IdRipetizioneNavigation { get; set; }
    }
}

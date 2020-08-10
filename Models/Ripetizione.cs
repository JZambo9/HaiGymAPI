using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Ripetizione
    {
        public Ripetizione()
        {
            Appunto = new HashSet<Appunto>();
        }

        public int IdRipetizione { get; set; }
        public int IdSerie { get; set; }
        public int? NumSet { get; set; }
        public int? MinReps { get; set; }
        public int? MaxReps { get; set; }

        public virtual Serie IdSerieNavigation { get; set; }
        public virtual ICollection<Appunto> Appunto { get; set; }
    }
}

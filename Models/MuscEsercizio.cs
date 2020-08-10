using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class MuscEsercizio
    {
        public int Id { get; set; }
        public int IdMuscolo { get; set; }
        public int IdEsercizio { get; set; }

        public virtual Esercizio IdEsercizioNavigation { get; set; }
        public virtual Muscolo IdMuscoloNavigation { get; set; }
    }
}

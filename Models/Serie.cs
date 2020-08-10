using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Serie
    {
        public Serie()
        {
            Ripetizione = new HashSet<Ripetizione>();
        }

        public int IdSerie { get; set; }
        public int IdEsercizio { get; set; }
        public int IdGiorno { get; set; }

        public virtual Esercizio IdEsercizioNavigation { get; set; }
        public virtual Giorno IdGiornoNavigation { get; set; }
        public virtual ICollection<Ripetizione> Ripetizione { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class AttrEsercizio
    {
        public int Id { get; set; }
        public int IdAttrezzo { get; set; }
        public int IdEsercizio { get; set; }

        public virtual Attrezzo IdAttrezzoNavigation { get; set; }
        public virtual Esercizio IdEsercizioNavigation { get; set; }
    }
}

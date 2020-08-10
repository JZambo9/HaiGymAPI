using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Esercizio
    {
        public Esercizio()
        {
            AttrEsercizio = new HashSet<AttrEsercizio>();
            MuscEsercizio = new HashSet<MuscEsercizio>();
            Serie = new HashSet<Serie>();
        }

        public int IdEsercizio { get; set; }
        public string NomeEsercizio { get; set; }
        public int IdTipo { get; set; }

        public virtual TipoEsercizio IdTipoNavigation { get; set; }
        public virtual ICollection<AttrEsercizio> AttrEsercizio { get; set; }
        public virtual ICollection<MuscEsercizio> MuscEsercizio { get; set; }
        public virtual ICollection<Serie> Serie { get; set; }
    }
}

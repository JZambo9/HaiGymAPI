using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class TipoEsercizio
    {
        public TipoEsercizio()
        {
            Esercizio = new HashSet<Esercizio>();
        }

        public int IdTipo { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Esercizio> Esercizio { get; set; }
    }
}

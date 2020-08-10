using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Atleta
    {
        public Atleta()
        {
            Scheda = new HashSet<Scheda>();
        }

        public string IdAtleta { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public virtual ICollection<Scheda> Scheda { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Attrezzo
    {
        public Attrezzo()
        {
            AttrEsercizio = new HashSet<AttrEsercizio>();
        }

        public int IdAttrezzo { get; set; }
        public string NomeAttrezzo { get; set; }

        public virtual ICollection<AttrEsercizio> AttrEsercizio { get; set; }
    }
}

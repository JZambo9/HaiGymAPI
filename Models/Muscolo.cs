using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Muscolo
    {
        public Muscolo()
        {
            MuscEsercizio = new HashSet<MuscEsercizio>();
        }

        public int IdMuscolo { get; set; }
        public string NomeMuscolo { get; set; }

        public virtual ICollection<MuscEsercizio> MuscEsercizio { get; set; }
    }
}

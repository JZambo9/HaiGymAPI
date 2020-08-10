using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Giorno
    {
        public Giorno()
        {
            Serie = new HashSet<Serie>();
        }

        public int IdGiorno { get; set; }
        public int IdScheda { get; set; }

        public virtual Scheda IdSchedaNavigation { get; set; }
        public virtual ICollection<Serie> Serie { get; set; }
    }
}

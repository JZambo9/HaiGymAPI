using System;
using System.Collections.Generic;

namespace HayGym_API.Models
{
    public partial class Scheda
    {
        public Scheda()
        {
            Giorno = new HashSet<Giorno>();
        }

        public int IdScheda { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public int? Settimane { get; set; }
        public int? Giorni { get; set; }
        public string IdAtleta { get; set; }

        public virtual Atleta IdAtletaNavigation { get; set; }
        public virtual ICollection<Giorno> Giorno { get; set; }
    }
}

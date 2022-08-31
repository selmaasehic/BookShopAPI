using System;
using System.Collections.Generic;

namespace seminarskiBooks.Models
{
    public partial class Zanr
    {
        public Zanr()
        {
            Knjigas = new HashSet<Knjiga>();
        }

        public int Idzanr { get; set; }
        public string NazivZanra { get; set; } = null!;

        public virtual ICollection<Knjiga> Knjigas { get; set; }
    }
}

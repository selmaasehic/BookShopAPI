using System;
using System.Collections.Generic;

namespace seminarskiBooks.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Knjigas = new HashSet<Knjiga>();
        }

        public int Idautor { get; set; }
        public string ImeAuotra { get; set; } = null!;
        public string PrezimeAuotra { get; set; } = null!;

        public virtual ICollection<Knjiga> Knjigas { get; set; }
    }
}

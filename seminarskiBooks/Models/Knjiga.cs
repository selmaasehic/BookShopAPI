using System;
using System.Collections.Generic;

namespace seminarskiBooks.Models
{
    public partial class Knjiga
    {
        public int Idknjiga { get; set; }
        public string? NazivKnjige { get; set; }
        public int Idautor { get; set; }
        public int Idzanr { get; set; }
        public string IzdavackaKuca { get; set; } = null!;
        public DateTime DatumIzdavanja { get; set; }

        public virtual Autor IdautorNavigation { get; set; } = null!;
        public virtual Zanr IdzanrNavigation { get; set; } = null!;
    }
}

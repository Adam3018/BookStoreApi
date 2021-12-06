using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApi.EF
{
    public partial class Knjiga
    {
        public int KnjigaId { get; set; }
        public string NazivKnjige { get; set; }
        public int CenaKnjige { get; set; }
        public int ZanrId { get; set; }
        public int AutorId { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Zanr Zanr { get; set; }
    }
}

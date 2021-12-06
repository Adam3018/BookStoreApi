using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApi.EF
{
    public partial class Zanr
    {
        public Zanr()
        {
            Knjigas = new HashSet<Knjiga>();
        }

        public int ZanrId { get; set; }
        public string ZanrNaziv { get; set; }

        public virtual ICollection<Knjiga> Knjigas { get; set; }
    }
}

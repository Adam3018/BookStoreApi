using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreApi.EF
{
    public partial class Autor
    {
        public Autor()
        {
            Knjigas = new HashSet<Knjiga>();
        }

        public int AutorId { get; set; }
        public string ImeAutora { get; set; }
        public string PrezimeAutora { get; set; }

        public virtual ICollection<Knjiga> Knjigas { get; set; }
    }
}

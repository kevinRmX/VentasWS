using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}

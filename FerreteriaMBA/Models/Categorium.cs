using System;
using System.Collections.Generic;

namespace FerreteriaMBA.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}

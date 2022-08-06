using System;
using System.Collections.Generic;

namespace FerreteriaMBA.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Codigos = new HashSet<Codigo>();
        }

        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public double? Precio { get; set; }
        public int? Cantidad { get; set; }
        public string? Codigo { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual ICollection<Codigo> Codigos { get; set; }
    }
}

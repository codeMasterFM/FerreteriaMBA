using System;
using System.Collections.Generic;

namespace FerreteriaMBA.Models
{
    public partial class Codigo
    {
        public int IdCodigo { get; set; }
        public int? IdProducto { get; set; }
        public string? Estatus { get; set; }
        public string? Codigo1 { get; set; }
        public string? Cantidad { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
    }
}

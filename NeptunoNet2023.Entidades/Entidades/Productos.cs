using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Entidades.Entidades
{
    public class Productos
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }


        public Categoria categoria { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
    }
}

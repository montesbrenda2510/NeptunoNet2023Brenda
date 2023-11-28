using NeptunoNet2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Entidades.Dtos
{
    public class ProductoDto:ICloneable
    {
        public int ProductoId { get; set; }
        public string? NombreProducto { get; set; }

        public string? NombreCategoria { get; set; }
        public decimal PrecioUnitario  { get; set; }
        public int Strock { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Entidades.Entidades
{
    public class Clientes
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public Pais pais { get; set; }
        public int PaisId { get; set; }
        public Ciudad ciudad { get; set; }
        public int CiudadId { get; set; }

    }
}

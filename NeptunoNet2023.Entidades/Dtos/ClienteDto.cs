using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Entidades.Dtos
{
    public class ClienteDto:ICloneable
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        
        public string NombrePais{ get; set; }
       
        public string NombreCiudad { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}

using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Dtos;
using NeptunoNet2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Servicios.Servicios
{
    
    
    public class ServicioProducto:IServicioProducto
    {
       private readonly RepositorioProducto _repositorioProducto;
        public ServicioProducto()
        {
            _repositorioProducto = new RepositorioProducto();
        }

        public List<ProductoDto> GetProductos()
        {
            try
            {
                return _repositorioProducto.GetProductos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using NeptunoNet2023.Entidades.Dtos;
using NeptunoNet2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Servicios.Interfaces
{
    public interface IServiciosClientes
    {
        List<ClienteDto> GetAll();
    }
}

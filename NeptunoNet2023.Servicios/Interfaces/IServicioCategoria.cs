using NeptunoNet2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Servicios.Interfaces
{
    public interface IServicioCategoria
    {
        bool Existe(Categoria categoria);
        void Guardar(Categoria categoria);
        void Borrar(int CategoriaId);
        List<Categoria> GetAll();
    }
}

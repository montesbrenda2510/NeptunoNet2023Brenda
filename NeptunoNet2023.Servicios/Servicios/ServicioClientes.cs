using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Dtos;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
    public class ServicioClientes : IServiciosClientes
    {
        private readonly RepositorioClientes _repositoriosClientes;
        public ServicioClientes()
        {
            _repositoriosClientes = new RepositorioClientes();
        }
        public List<ClienteDto> GetAll()
        {
            try
            {
                return _repositoriosClientes.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

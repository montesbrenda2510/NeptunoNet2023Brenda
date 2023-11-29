using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Dtos;
using System.Configuration;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly string _connectionString;
        public RepositorioClientes()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        

        private ClienteDto ConstruirCliente(SqlDataReader reader)
        {
            return new ClienteDto
            {
                
                ClienteId=reader.GetInt32(0),
                NombreCliente = reader.GetString(1),
                NombrePais=reader.GetString(2),
                NombreCiudad = reader.GetString(3)
            };
        }

        public List<ClienteDto> GetAll()
        {
            List<ClienteDto> clientes = new List<ClienteDto>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT cl.ClienteId, cl.NombreCliente, p.NombrePais , c.NombreCiudad
                        FROM Clientes cl
                        inner join Ciudades c on cl.CiudadId=c.CiudadId
						inner join Paises p on cl.PaisId= p.PaisId";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClienteDto cliente = ConstruirCliente(reader);
                            clientes.Add(cliente);

                        }
                    }
                }

                return clientes;
            }
        }
    }
}

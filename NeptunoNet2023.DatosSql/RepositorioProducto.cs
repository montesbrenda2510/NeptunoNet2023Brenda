using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Dtos;
using NeptunoNet2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.DatosSql
{
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly string _connectionString;
        public RepositorioProducto()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public List<ProductoDto> GetProductos()
        {
            List<ProductoDto> productoDtos = new List<ProductoDto>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectQuery = @"SELECT p.ProductoId, p.NombreProducto, c.NombreCategoria , p.PrecioUnitario, p.Stock
                        FROM Productos p
                        inner join Categorias c on p.categoriaId=c.CategoriaId
						";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductoDto productoDto = ConstruirProducto(reader);
                            productoDtos.Add(productoDto);
                        }
                    }
                }
            }
            return productoDtos;
        }

        private ProductoDto ConstruirProducto(SqlDataReader reader)
        {
            return new ProductoDto
            {
                ProductoId=reader.GetInt32(0),
                NombreProducto=reader.GetString(1),
                NombreCategoria=reader.GetString(2),
                PrecioUnitario=reader.GetDecimal(3),
                Strock=reader.GetInt32(4)
                
            };
        }
    }
}

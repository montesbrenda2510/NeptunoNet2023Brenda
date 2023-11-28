using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.Entidades.Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NeptunoNet2023.DatosSql
{
    public class RepositorioCategorias : IRepositorioCategorias
    {

        private readonly string _connectionString;
        public RepositorioCategorias()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Categoria categoria)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Categorias (NombreCategoria,Descripcion ) VALUES (@NombreCategoria, @Descripcion );
                                       SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                    comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar);
                    comando.Parameters["@Descripcion"].Value = categoria.Descripcion;


                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    categoria.CategoriaId = id;

                }
            }
        }

        public void Borrar(int CategoriaId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Categorias WHERE CategoriaId=@CategoriaId";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    comando.Parameters["@CategoriaId"].Value = CategoriaId;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Categoria categoria)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string updateQuery = @"UPDATE Categorias SET NombreCategoria=@NombreCategoria, Descripcion=@Descripcion
        		WHERE CategoriaId=@CategoriaId";
                using (var comando = new SqlCommand(updateQuery, conn))
                {
                    comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    comando.Parameters["@CategoriaId"].Value = categoria.CategoriaId;

                    comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                    comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar);
                    comando.Parameters["@Descripcion"].Value = categoria.Descripcion;


                    comando.ExecuteNonQuery();
                }
            }
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string selectQuery;
                    if (categoria.CategoriaId == 0)
                    {
                        selectQuery = "SELECT COUNT(*) FROM Categorias WHERE NombreCategoria=@NombreCategoria";

                    }
                    else
                    {
                        selectQuery = "SELECT COUNT(*) FROM Categorias WHERE NombreCategoria=@NombreCategoria AND CategoriaId<>@CategoriaId";

                    }
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                        comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                        if (categoria.CategoriaId != 0)
                        {
                            comando.Parameters.Add("@CategoriaId", SqlDbType.Int);
                            comando.Parameters["@CategoriaId"].Value = categoria.CategoriaId;

                        }

                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Categoria> GetAll()
            {
                List<Categoria> categorias = new List<Categoria>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string selectQuery = @"SELECT CategoriaId, NombreCategoria, 
                        Descripcion FROM Categorias";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Categoria categoria = ConstruirCategoria(reader);
                                categorias.Add(categoria);
                            }
                        }
                    }
                }
                return categorias;

            }

            private Categoria ConstruirCategoria(SqlDataReader reader)
            {
                return new Categoria
                {
                    CategoriaId = reader.GetInt32(0),
                    NombreCategoria = reader.GetString(1),
                    Descripcion = reader.GetString(2)
                };
            }
        
    }
}

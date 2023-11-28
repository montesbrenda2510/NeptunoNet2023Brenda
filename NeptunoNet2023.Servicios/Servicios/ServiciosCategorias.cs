using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
    public class ServiciosCategorias:IServicioCategoria
    {
        private readonly RepositorioCategorias _repositorioCategorias;
        public ServiciosCategorias()
        {
            _repositorioCategorias = new RepositorioCategorias();
        }

        public void Borrar(int CategoriaId)
        {
            try
            {
                _repositorioCategorias.Borrar(CategoriaId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                return _repositorioCategorias.Existe(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Categoria> GetAll()
        {
            try
            {
                return _repositorioCategorias.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Guardar(Categoria categoria)
        {
           
            //try
            //{
                try
                {
                    _repositorioCategorias.Agregar(categoria);
                    _repositorioCategorias.Editar(categoria);
                }
                catch (Exception)
                {

                    throw;
                }
                //if (categoria.CategoriaId == 0)
                //{
                //    _repositorioCategorias.Agregar(categoria);
                //}
                //else
                //{
                //    _repositorioCategorias.Editar(categoria);
                //}
            //}
            //catch (Exception ex)
            //{

            //    throw ;
            //}
        }
    }
}

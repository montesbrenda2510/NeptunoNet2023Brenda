using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Comun.Interfaces
{
	public interface IRepositorioCategorias
	{
		List<Categoria> GetAll();
        void Agregar(Categoria categoria);
       void Borrar(int CategoriaId);
        void Editar(Categoria categoria);
        bool Existe(Categoria categoria);

    }
}
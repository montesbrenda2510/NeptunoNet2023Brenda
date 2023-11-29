using NeptunoNet2023.Entidades.Dtos.ComboDto;
using NeptunoNet2023.Entidades.Entidades;

namespace NeptunoNet2023.Comun.Interfaces
{
	public interface IRepositorioPaises
	{
		List<Pais> GetAll();
		int Agregar(Pais pais);
		int Borrar(Pais pais);
		int Editar(Pais pais);

		bool Existe(Pais pais);
		bool EstaRelacionado(Pais pais);
		Pais GetPais(int paisId);
		List<PaisComboDto> GetComboDtos();
	}
}

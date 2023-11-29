using NeptunoNet2023.Entidades.Dtos.ComboDto;
using NeptunoNet2023.Servicios.Interfaces;
using NeptunoNet2023.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunoNet2023.Windows.Helpers
{
    public static class ComboHelpers
    {
        public static void CargarComboPais(ref ComboBox combo)
        {
            IServiciosPaises servicios= new ServiciosPaises();
            var lista = servicios.GetComboDtos();
            var nuevoPais = new PaisComboDto() { PaisId = 0, NombrePais = "Seleccionar Pais" };
            lista.Insert(0, nuevoPais); 
            combo.DataSource = lista;
            combo.DisplayMember = "NombrePais";
            combo.ValueMember = "PaisId";
            combo.SelectedIndex = 0;    

        }
    }
}

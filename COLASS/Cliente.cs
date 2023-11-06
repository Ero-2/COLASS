using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLASS
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public TipoCliente Tipo { get; set; }

        public Cliente(string nombre, TipoCliente tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
        }
    }
}

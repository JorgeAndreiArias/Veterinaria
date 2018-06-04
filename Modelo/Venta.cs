using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Modelo
{
    class Venta
    {
        public Usuario User { get; set; }
        public Accesorios Accesory { get; set; }
        public string NombreCliente { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}

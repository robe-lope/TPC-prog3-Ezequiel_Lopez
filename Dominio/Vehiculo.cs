using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Dominio
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public int Kilometraje { get; set; }
        public bool Activo { get; set; }
        public Cliente Cliente { get; set; }

        public string Descripcion => $"{Marca} {Modelo} ({Anio}) - {Patente}";
    }
}

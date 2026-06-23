using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Repuesto
    {
        public int IdRepuesto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public bool Activo { get; set; }
        public MarcaRepuesto Marca { get; set; }
        public CategoriaRepuesto Categoria { get; set; }

        public bool StockBajo => StockActual <= StockMinimo;
    }
}

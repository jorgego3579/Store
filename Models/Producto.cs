using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Producto
    {
        public int ID { get; set; }

        public String NombreProducto { get; set; }

        public decimal precioEnvio { get; set; }

        public decimal DistanciaKm { get; set; }

        public decimal PrecioProducto { get; set; }

    }
}

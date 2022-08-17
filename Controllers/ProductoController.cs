using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class ProductoController : Controller
    {
        public IList<decimal> Datos { get; set; }
        private decimal IVA { get; set; }
        private decimal MontoBruto { get; set; }
        private decimal EnvioDolar { get; set; }
        private decimal EnvioEuro { get; set; }



        public IList<decimal> CalcularMontos(decimal precio, decimal tcambioDolar, decimal tcambioEuro, decimal costoEnvio)
        {
            IVA = precio * (decimal)0.015;
            Datos.Add(IVA);

            MontoBruto = precio * (decimal)0.085;
            Datos.Add(MontoBruto);

            EnvioDolar = tcambioDolar * costoEnvio;
            Datos.Add(EnvioDolar);

            EnvioEuro = tcambioEuro * costoEnvio;
            Datos.Add(EnvioEuro);

            return Datos;
        }
    }
}

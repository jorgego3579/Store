using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Controllers;

namespace Store.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        private ConsumerWStCambio consumerWS;

        private ProductoController cproducto;

        private IList<decimal> operaciones { get; set; }

        public IndexModel(Store.Data.StoreContext context)
        {
            _context = context;
            consumerWS = new ConsumerWStCambio();
            cproducto = new ProductoController();
        }

        public Producto Producto { get; set; }

        public TipoCambio tcambio { get; set; }

        public async Task OnGetAsync(int? id)
        {
            //Busqueda en la base de datos el primer producto que coincida con el ID de producto uso de EFCore para acceder a la BDD
            Producto = await _context.Producto.FirstOrDefaultAsync(m => m.ID == id);

            //Obtiene los tipos de cambio desde el web service
            tcambio = await consumerWS.GetTipoCambioHoy();

            //Obtieene las operaciones de IVA, Monto Bruto y costos de envio
            operaciones = cproducto.CalcularMontos(Producto.PrecioProducto, tcambio.tCambioDolar, tcambio.tCambioEuro, Producto.precioEnvio);

            System.Console.WriteLine("IVA:" + operaciones[0].ToString());
            System.Console.WriteLine("Monto Bruto:" + operaciones[1].ToString());
            System.Console.WriteLine("Monto Envio Dolares:" + operaciones[2].ToString());
            System.Console.WriteLine("Monto Envio Euros: " + operaciones[3].ToString());

        }
    }
}

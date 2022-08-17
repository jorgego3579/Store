using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Store.Models;
using Store.Services;

namespace Store.Controllers
{
    public class ConsumerWStCambio
    {
        static HttpClient client;

        TipoCambio tcambio;

        public ConsumerWStCambio()
        {
            client = new HttpClient();
            tcambio = new TipoCambio();
        }

        public async Task<TipoCambio> GetTipoCambioHoy()
        {
            WSTipoCambio ws = new WSTipoCambio();
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://www.gettCambio/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "http://consumews?";

            try
            {
                TipoCambio tcambio = new TipoCambio();

                tcambio = await ws.GetProductAsync(url);

  

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return tcambio;
        }

    }
}

using System.Net.Http;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Services
{
    public class WSTipoCambio
    {
        static HttpClient client;

        public WSTipoCambio()
        {
            client = new HttpClient();
        }

        public  async Task<TipoCambio> GetProductAsync(string path)
        {
            TipoCambio tcambio = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //tcambio = await response.Content.<TipoCambio>();
            }
            return tcambio;
        }
    }
}

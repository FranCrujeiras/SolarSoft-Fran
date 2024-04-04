using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebAppBlazor.Components.Models;

namespace WebAppBlazor.Components.Services
{
 
    public class TerrenoService : ITerrenoService
    {
        private readonly HttpClient HttpClient;

        public TerrenoService(HttpClient httpClient)
        {
            HttpClient = httpClient;
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public Task<bool> DeletePanel(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Terreno> GetTerreno(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Terreno[]> GetTerrenos()
        {
            var response = HttpClient.GetAsync("GetTerreno").Result;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var terrenos = JsonConvert.DeserializeObject<Terreno[]>(json);
                return terrenos;
            }
            return null;
        }

        public Task<bool> PutAnchoTerreno(int Id, double AnchoTerreno)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutAnguloEstructura(int Id, int AnguloEstructura)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutLargoTerreno(int Id, double LargoTerreno)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutLatitud(int Id, double Latitud)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutLongitud(int Id, double Longitud)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutModeloPanel(int Id, string ModeloPanel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutPotenciaPanel(int Id, int PotenciaPanel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutVoltajePanel(int Id, double VoltajePanel)
        {
            throw new NotImplementedException();
        }
    }
}


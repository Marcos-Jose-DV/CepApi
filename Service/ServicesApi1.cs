
using ApiCep.Models;
using Newtonsoft.Json;

namespace ApiCep.Service
{
    internal class ServicesApi
    {
        public async Task<ServicesCep> Integracao(string Cep)
        {

            using HttpClient httpClient = new();

            var response = await httpClient.GetAsync($"https://brasilapi.com.br/api/cep/v1/{Cep}");
            var Content = await response.Content.ReadAsStringAsync();

            ServicesCep jsonObject = JsonConvert.DeserializeObject<ServicesCep>(Content);
            if (jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new ServicesCep
                {
                    Vericacao = true
                };
            }
        }
        internal Task<ServicesCep> Integracao(object cep)
        {
            throw new NotImplementedException();
        }
    }
}
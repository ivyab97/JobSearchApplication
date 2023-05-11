using Aplication.Interfaces.IClient;

namespace Infrastructure.Client
{
    public class ClientGeorefArApi : IClientGeorefArApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://apis.datos.gob.ar/georef/api";

        public ClientGeorefArApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAllProvinces()
        {
            var url = $"{_baseUrl}/provincias";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAllCities(int provinceId)
        {
            var url = $"{_baseUrl}/municipios?provincia={provinceId}&campos=id,nombre&max=100";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}

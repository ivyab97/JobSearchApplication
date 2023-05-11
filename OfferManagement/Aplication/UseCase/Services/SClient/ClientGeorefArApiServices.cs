using Aplication.DTO.Response;
using Aplication.Interfaces.IClient;
using System.Text.Json;

namespace Aplication.UseCase.Services.SClient
{
    public class ClientGeorefArApiServices : IClientGeorefArApiServices
    {
        private readonly IClientGeorefArApi _clientGeorefArApi;

        public ClientGeorefArApiServices(IClientGeorefArApi clientGeorefArApi)
        {
            _clientGeorefArApi = clientGeorefArApi;
        }

        public async Task<bool> ValidateCity(int provinciaId, int ciudadId)
        {
            var content = await _clientGeorefArApi.GetAllCities(provinciaId);

            var cities = JsonSerializer.Deserialize<CityAllResponse>(content);

            foreach (var item in cities.Cities)
            {
                if (int.Parse(item.id) == ciudadId)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ValidateProvince(int id)
        {
            var content = await _clientGeorefArApi.GetAllProvinces();

            var provincesList = JsonSerializer.Deserialize<ProvinceAllResponse>(content);

            foreach (var item in provincesList.provincies)
            {
                if (int.Parse(item.id) == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

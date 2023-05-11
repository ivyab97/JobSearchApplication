namespace Aplication.Interfaces.IClient
{
    public interface IClientGeorefArApi
    {
        public Task<string> GetAllProvinces();
        public Task<string> GetAllCities(int provinceId);

    }
}

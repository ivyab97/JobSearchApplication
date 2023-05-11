namespace Aplication.Interfaces.IClient
{
    public interface IClientGeorefArApiServices
    {
        public Task<bool> ValidateProvince(int id);

        public Task<bool> ValidateCity(int provinceId, int cityId);
    }
}

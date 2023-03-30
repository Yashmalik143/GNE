using Services.DTOClass;

namespace Services.IServices
{
    public interface ICurrencyServices
    {
        public Task<List<CurrencyDTO>> GetAllCurrencyList();
        public Task<string> AddOrUpdateCurrency(CurrencyDTO currencyDTO);
        public Task<string> DeleteCurrencyById(int id);
    }
}

using DataAccess.Entity;

namespace DataAccess.IDataAcces
{
    public interface ICurrency
    {
        public Task<List<Currency>> GetAllCurrency();
        public Task<string> AddOrUpdateCurrency(Currency currency);
        public Task<string> DeleteCurrencyById(int id);

    }
}

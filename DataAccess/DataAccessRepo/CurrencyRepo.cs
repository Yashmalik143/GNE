using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccessRepo
{
    public class CurrencyRepo : ICurrency
    {
        private readonly Context.GneProjectContext _context;
        public CurrencyRepo(Context.GneProjectContext context)
        {
            _context = context;
        }
        public async Task<string> AddOrUpdateCurrency(Currency currency)
        {
            var currencyData = await _context.Currencies.Where(x => x.CurrencyCode == currency.CurrencyCode).FirstOrDefaultAsync();
            if (currencyData == null)
            {
                currencyData = new Currency
                {
                    CurrencyCode = currency.CurrencyCode,
                    CurrencyName = currency.CurrencyName,
                    Symbol = currency.Symbol,

                };
                _context.Currencies.Add(currencyData);
            }
            else
            {
                currencyData.CurrencyName = currency.CurrencyName;
            }
            await _context.SaveChangesAsync();
            return (currency.CurrencyId == 0 ? "Added Succesfully......:)" : "Updated Successfully");

        }

        public async Task<string> DeleteCurrencyById(int id)
        {

            var currencyById = await _context.Currencies.FirstOrDefaultAsync(x => x.CurrencyId == id);
            if (currencyById == null)
                return ("Currency Not Found.....");
            _context.Remove(currencyById);
            await _context.SaveChangesAsync();
            return ("Deleted Succesfully......:)");
        }


        public async Task<List<Currency>> GetAllCurrency()
        {
            return await _context.Currencies.ToListAsync();

        }
    }
}

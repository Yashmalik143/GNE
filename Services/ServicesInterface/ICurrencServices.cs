using Services.DTOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesInterface
{
    public interface ICurrencServices
    {
        public Task<string> AddOrUpdateCurrency(CurrencyDTO currencyDTO);
        public  Task<string> DeleteCurrencyById(int id);
        public Task<List<CurrencyDTO>> GetAllCurrencyList();
    }
}

using AutoMapper;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.DTOClass;
using Services.ServicesInterface;

namespace Services.ServicesRepo
{

    public class CurrencyServices : ICurrencServices

    {
        private readonly ICurrency _currency;
        private IMapper _mapper;
        public CurrencyServices(ICurrency currency,IMapper mapper)
        {
            _currency = currency;
            _mapper = mapper;
        }

        public  async Task<string> AddOrUpdateCurrency(CurrencyDTO currencyDTO)
        {
            var dtoToUser = _mapper.Map<CurrencyDTO, Currency>(currencyDTO);

            var currencyData = await _currency.AddOrUpdateCurrency(dtoToUser);
            return currencyData;

           
        }

        public async Task<string> DeleteCurrencyById(int id)
        {
           var currencyById=await _currency.DeleteCurrencyById(id);
            return currencyById;
        }

        public async Task<List<CurrencyDTO>> GetAllCurrencyList()
        {
            var listOfCurrency =await _currency.GetAllCurrency();
            var dtoToClass = _mapper.Map<List<Currency>, List<CurrencyDTO>>(listOfCurrency);
            return dtoToClass;
        }
    }
}

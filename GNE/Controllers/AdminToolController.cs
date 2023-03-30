using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOClass;
using Services.ServicesInterface;
using Services.ServicesRepo;

namespace Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminToolController : ControllerBase
    {
        private readonly ICurrencServices _currency;
        private readonly ICategoryTypeServices _categoryType;
        private readonly ICounterPartyServices _counterParty;
        private readonly IThresholdServices _threshold;
        public AdminToolController(ICurrencServices currency, ICategoryTypeServices categoryType, ICounterPartyServices counterParty, IThresholdServices threshold)
        {
            _currency = currency;
            _categoryType = categoryType;
            _counterParty = counterParty;
            _threshold = threshold;
        }
        [HttpGet]
        public async Task<IEnumerable<CurrencyDTO>> Currencies()
        {
            return await _currency.GetAllCurrencyList();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCurrencyById(int id)
        {
            var dataById=await _currency.DeleteCurrencyById(id);
            return Ok(dataById);
        }
        [HttpPut]
        public async Task<string> AddOrUpdateCurrency(CurrencyDTO currencyDTO)
        {
            return await _currency.AddOrUpdateCurrency(currencyDTO);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryTypes()
        {
            var listOfCategory = await _categoryType.GetAllCategoryList();
            return Ok(listOfCategory);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var DataById = await _categoryType.DeleteCategoryById(id);
            return Ok(DataById);
        }
        [HttpPut]
        public async Task<string> AddOrUpdateCategory(CategoryTypeDTO categoryDTO)
        {
          return await _categoryType.AddOrUpdateCategory(categoryDTO);
           
        }
        [HttpGet]
        public async Task<IActionResult> CounterParties()
        {
            var ListOfCounterParty = await _counterParty.GetListOfParty();
            return Ok(ListOfCounterParty);
        }

        [HttpPut]
        public async Task<string> CounterPartyEdit(CounterPartyDTO counterPartyDTO)
        {
            return await _counterParty.CounterPartyEdit(counterPartyDTO);
            
        }


        [HttpGet]
        public async Task<IActionResult> Thresholds()
        {
            var ListOfThreshold=await _threshold.GetListOfThreshold();
            return Ok(ListOfThreshold);
        }
    }


   

}

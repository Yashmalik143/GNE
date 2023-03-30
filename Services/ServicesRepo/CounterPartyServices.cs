using AutoMapper;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Services.DTOClass;
using Services.ServicesInterface;

namespace Services.ServicesRepo
{
    public class CounterPartyServices : ICounterPartyServices
    {
        private readonly ICounterParty _counterParty; 
        private IMapper _mapper;
        public CounterPartyServices(ICounterParty counterParty,IMapper mapper)
        {
            _counterParty = counterParty;
            _mapper = mapper;
        }
        public async Task<string> CounterPartyEdit(CounterPartyDTO counterPartyDTO)
        {
            //var DtoToUser = _mapper.Map<CategoryTypeDTO, Category>(categoryDTO);
            var DtoToUser = _mapper.Map<CounterPartyDTO, CounterParty>(counterPartyDTO);
            var DataCounter = await _counterParty.EditOrApproveCounterParty(DtoToUser);
            return DataCounter;
            //dbhqwadQW
        }

        public async Task<List<CounterPartyDTO>> GetListOfParty()
        {
            var listOfCounter = await _counterParty.GetListOfCounter();
            var dtoToClass = _mapper.Map<List<CounterParty>, List<CounterPartyDTO>>(listOfCounter);
            return dtoToClass;
        }
    }
}

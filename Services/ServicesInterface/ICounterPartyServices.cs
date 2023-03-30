using DataAccess.Entity;
using Services.DTOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesInterface
{
    public interface ICounterPartyServices
    {
        public Task<List<CounterPartyDTO>> GetListOfParty();
        public Task<string> CounterPartyEdit(CounterPartyDTO counterPartyDTO);

    }
}
 
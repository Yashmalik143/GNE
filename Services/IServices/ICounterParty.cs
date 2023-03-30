using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICounterParty
    {
        public Task<List<CounterParty>> GetListOfParty();
        public Task<string> UpdateCounterParty(CounterParty counterParty);
    }
}

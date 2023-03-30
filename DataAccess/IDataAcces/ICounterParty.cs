using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDataAcces
{
    public interface ICounterParty
    {
        public Task<List<CounterParty>> GetListOfCounter();
        public Task<string> EditOrApproveCounterParty(CounterParty counterParty);
       
    }
}

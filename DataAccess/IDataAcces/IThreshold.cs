using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDataAcces
{
    public interface IThreshold
    {
        public Task<List<Threshold>> GetAllThresholdList();
    }
}

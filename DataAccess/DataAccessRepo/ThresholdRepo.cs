using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessRepo
{
    public class ThresholdRepo : IThreshold
    {
        private readonly Context.GneProjectContext _context;
        public ThresholdRepo(Context.GneProjectContext context)
        {
            _context = context;
        }
        public async Task<List<Threshold>> GetAllThresholdList()
        {

            return await _context.Thresholds.ToListAsync();


        }
    }
}

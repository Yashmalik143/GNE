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
  
   
    public class ApprovalLevelRepo: IApprovalLevel
    {

        private readonly Context.GneProjectContext _context;

        public ApprovalLevelRepo(GneProjectContext context)
        {
            _context = context;
        }

        public async Task<IList<ApprovalLevel>>GetApprovalLevelAsync()
        {
           var ab = await _context.ApprovalLevels.ToListAsync();
            return ab;
        }
    }
}

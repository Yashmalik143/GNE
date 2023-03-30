using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessRepo
{
    public class ApprovalDetailRepo : IApprovalDetail
    {
        private readonly GneProjectContext gneProjectContext;

        public ApprovalDetailRepo(GneProjectContext gneProjectContext)
        {
            this.gneProjectContext = gneProjectContext;
        }

        public async Task<ApprovalDetail> AddApprovalDetail(ApprovalDetail approvalDetail)
        {
            try
            {
                gneProjectContext.ApprovalDetails.Add(approvalDetail);

                gneProjectContext.SaveChanges();

                return approvalDetail;
            }
            catch (Exception ex) {
                throw; 
            }
           

            
        }
    }
}

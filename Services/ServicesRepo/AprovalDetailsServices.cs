using DataAccess.Entity;
using DataAccess.IDataAcces;
using Services.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepo
{
    public class AprovalDetailsServices : IApprovalDetailService
    {
        private readonly IApprovalLevel approvalLevel;
        private readonly IApprovalDetail approvalDetail;

        public AprovalDetailsServices(IApprovalLevel approvalLevel, IApprovalDetail approvalDetail)
        {
            this.approvalLevel = approvalLevel;
            this.approvalDetail = approvalDetail;
        }

        public async Task<string> AddDetails(int level, int approvalId,string complTitle)
        {




            //for(int i =1;i<=level;i++)
            //{
            //    ApprovalDetail a = new ApprovalDetail();
            //    a.ApprovarTitle = list[i].ApprovalPosition;
            //    a.ApprovalId = approvalId;
            //    a.ApprovarName = "System";
            //    a.Status = "Pending";
            //    approvalDetail.AddApprovalDetail(a);

            //}
            try
            {
                ApprovalDetail compliance = new ApprovalDetail();
                compliance.ApprovalId = approvalId;
                compliance.ApprovarName = "System";
                compliance.ApprovarTitle = complTitle;
                compliance.Status = "Pending";
                approvalDetail.AddApprovalDetail(compliance);


                var list = approvalLevel.GetApprovalLevelAsync().Result;

                for (int i = 1; i <= level; i++)
                {
                    ApprovalDetail a = new ApprovalDetail();
                    a.ApprovarTitle = list[i].ApprovalPosition;
                    a.ApprovalId = approvalId;
                    a.ApprovarName = "System";
                    a.Status = "Pending";
                    approvalDetail.AddApprovalDetail(a);

                }


                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}

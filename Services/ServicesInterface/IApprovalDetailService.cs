using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesInterface
{
    public interface IApprovalDetailService
    {
        Task<string> AddDetails(int level, int approvalId, string complTitle);
    }
}

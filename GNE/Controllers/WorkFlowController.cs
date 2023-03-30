using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServicesInterface;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IApprovalDetailService approvalDetailService;

        public WorkFlowController(IApprovalDetailService approvalDetailService)
        {
                this.approvalDetailService = approvalDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> AddApprovalDetails(int id,int level,string compTitle)
        {
            return Ok(await approvalDetailService.AddDetails(id, level,compTitle));

        }

    }
}

using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.DTOClass;
using Services.ServicesInterface;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GnEReceivedControllercs : ControllerBase
    {
        private readonly IGnEReceivedServices _received;
        public GnEReceivedControllercs(IGnEReceivedServices received)
        {
            _received = received;
        }
        [HttpPost]
        public IActionResult ReceiverForm(ReceiverMaster Form)
        {
            var data = _received.ReceiveForm(Form);
            return Ok(data);

        }
        [HttpGet]
        public IActionResult GetCurrentId()
        {
            var id = _received.CurrentGnEId();
            return Ok(id.Result);
        }
    }
}

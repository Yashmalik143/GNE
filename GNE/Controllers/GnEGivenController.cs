using DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOClass;
using Services.ServicesInterface;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GnEGivenController : ControllerBase
    {
        private readonly IGnEGivenServices _given;
        public GnEGivenController(IGnEGivenServices given)
        {
            _given = given;
        }
        [HttpGet("FormCode")]
        public IActionResult GetCurrentFormCode() {

            return Ok(_given.CurrentGnEId().Result);
        }
        [HttpGet]
        public IActionResult Get(int ModelId)
        {
            return Ok(_given.GetGiver(ModelId).Result);
        }
        [HttpPost]
        public IActionResult GivenForm(GivenMasterDTO model)
        {
            var fillForm=_given.GivenForm(model).Result;
            return Ok(fillForm);
        }
        [HttpPost("Recipient")]
        public IActionResult GivenRecipient(GiverRecipientDTO giverRecipientDTO)
        {
            return Ok(_given.GiverRecipient(giverRecipientDTO));
        }
        [HttpGet("GetModel")]
        public IActionResult GetModel(int ModelId) {

            return Ok(_given.GetModel(ModelId).Result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_given.GnEGiven);
        }
    }
}

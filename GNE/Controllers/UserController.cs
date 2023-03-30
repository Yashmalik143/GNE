using DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServicesInterface;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _user;
        public UserController(IUserServices user)
        {
            _user = user;
        }
       
        [HttpGet]
        public async  Task<IActionResult> UserInfo() 
        {
            var userLimitedData=await _user.GetUserInfo();
            return Ok(userLimitedData);
        }
    }
}

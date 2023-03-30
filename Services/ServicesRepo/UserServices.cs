using AutoMapper;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Services.DTOClass;
using Services.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepo
{

    public class UserServices : IUserServices
    {
    private readonly IUser _user;
        private readonly IMapper _mapper;
        public UserServices(IUser user,IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUserInfo()
        {
            var dataInfo =await _user.GetUserInfo();
            var dtoToClass = _mapper.Map<List<User>, List<UserDTO>>(dataInfo);
            return dtoToClass;

        }
    }
}

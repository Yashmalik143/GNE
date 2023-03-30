using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class UserDTO
    {

        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string UserDepartment { get; set; } = null!;

        public string UserTitle { get; set; } = null!;

        public int? SeniorId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class CategoryTypeDTO
    {
        public int Id {  get; set; }
        public string CategoryType { get; set; } = null!;

        public string CategoryName { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}

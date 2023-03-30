﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class GiverDetailDTO
    {
        public int GivenId { get; set; }

        public bool IsDeleted { get; set; } = false;

        public string CreatedBy { get; set; } 

        public DateTimeOffset CreatedOn { get; set; }

        public int CategoryId { get; set; }
    }
}

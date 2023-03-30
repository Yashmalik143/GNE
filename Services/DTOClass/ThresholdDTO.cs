using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class ThresholdDTO
    {
        public int ThresholdId { get; set; }

        public int ApprovallevelId { get; set; }

        public int MinAmount { get; set; }

        public int MaxAmount { get; set; }

        public string CategoryType { get; set; } = null!;

        public int PersonTypeId { get; set; }
    }
}

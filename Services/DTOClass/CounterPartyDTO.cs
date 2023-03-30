using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class CounterPartyDTO
    {
        public int Id {  get; set; }
        public string PartyName { get; set; } = null!;
        public string Status { get; set; }
    }
}

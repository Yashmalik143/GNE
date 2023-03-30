using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class GiverDTO
    {
      //  public int GiverModelId { get; set; }

        public string FormCode { get; set; }

        public string GiverName { get; set; } = null!;

        public string GiverOrganization { get; set; } = null!;

        public string GiverSubOrganization { get; set; } = null!;

      //  public DateTime? GivenDate { get; set; }

        public string Description { get; set; } = null!;

        public int CurrencyId { get; set; }

        public double CostLocal { get; set; }

        public double MarketLocal { get; set; }

        public bool IsSupplyChainVpapproved { get; set; }

        public string? Comments { get; set; }

     //   public string CreatedBy { get; set; } = null!;

      //  public DateTimeOffset? CreatedOn { get; set; }

        public int ExchangeRate { get; set; }

      //  public string? BussinessStatus { get; set; }

        //public string? ComplienceStatus { get; set; }



    }
}

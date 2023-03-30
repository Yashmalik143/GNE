using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class Currency
{
    public int CurrencyId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public virtual ICollection<GiverModel> GiverModels { get; } = new List<GiverModel>();

    public virtual ICollection<ReceiverModel> ReceiverModels { get; } = new List<ReceiverModel>();
}

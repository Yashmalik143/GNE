using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class ComplienceThreshold
{
    public int Id { get; set; }

    public string Approve { get; set; } = null!;

    public int MinAmount { get; set; }

    public int MaxAmount { get; set; }

    public string CategoryType { get; set; } = null!;

    public int PersonTypeId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public virtual PersonType PersonType { get; set; } = null!;
}

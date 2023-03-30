using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class Threshold
{
    public int ThresholdId { get; set; }

    public int ApprovallevelId { get; set; }

    public int MinAmount { get; set; }

    public int MaxAmount { get; set; }

    public string CategoryType { get; set; } = null!;

    public int PersonTypeId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public virtual ApprovalLevel Approvallevel { get; set; } = null!;

    public virtual PersonType PersonType { get; set; } = null!;
}

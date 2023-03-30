using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class Approval
{
    public int ApprovalId { get; set; }

    public string ReqEmail { get; set; } = null!;

    public int FormCode { get; set; }

    public string? Status { get; set; }

    public string? StatusBy { get; set; }

    public DateTime? StatusOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public virtual ICollection<ApprovalDetail> ApprovalDetails { get; } = new List<ApprovalDetail>();
}

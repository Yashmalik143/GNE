using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class ApprovalLevel
{
    public int ApprovalLevelId { get; set; }

    public string ApprovalPosition { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public virtual ICollection<Threshold> Thresholds { get; } = new List<Threshold>();
}

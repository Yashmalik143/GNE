using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class PersonType
{
    public int PersonTypeId { get; set; }

    public string PersonType1 { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset? CreatedOn { get; set; }

    public virtual ICollection<ComplienceThreshold> ComplienceThresholds { get; } = new List<ComplienceThreshold>();

    public virtual ICollection<GiverRecipient> GiverRecipients { get; } = new List<GiverRecipient>();

    public virtual ICollection<ReceiverModel> ReceiverModels { get; } = new List<ReceiverModel>();

    public virtual ICollection<Threshold> Thresholds { get; } = new List<Threshold>();
}

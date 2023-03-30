using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class CounterParty
{
    public int CounterPartyId { get; set; }

    public string PartyName { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public string? Status { get; set; }

    public string? StatusBy { get; set; }

    public DateTimeOffset? StatusOn { get; set; }

    public virtual ICollection<GiverRecipient> GiverRecipients { get; } = new List<GiverRecipient>();

    public virtual ICollection<ReceiverModel> ReceiverModels { get; } = new List<ReceiverModel>();
}

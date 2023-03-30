using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class GiverAttachment
{
    public int AttachmentId { get; set; }

    public string AttachmentTitle { get; set; } = null!;

    public string AttachmentPath { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public int GiverId { get; set; }

    public virtual GiverModel Giver { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DataAccess.Entity;

public partial class ReceiverAttachment
{
    public int Id { get; set; }

    public string AttachmentTitle { get; set; } = null!;

    public string AttachmentPath { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset CreatedOn { get; set; }

    public int ReceiverId { get; set; }

    public virtual ReceiverModel Receiver { get; set; } = null!;
}

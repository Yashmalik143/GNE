using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class GiverAttachmentDTO
    {
         

        public string AttachmentTitle { get; set; } = null!;

        public string AttachmentPath { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTimeOffset CreatedOn { get; set; }

        public int GiverId { get; set; }
    }
}

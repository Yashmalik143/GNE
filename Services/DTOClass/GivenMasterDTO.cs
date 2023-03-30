using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class GivenMasterDTO 
    {
        public GiverDTO GiverDTO { get; set; }
        public List<GiverRecipientDTO> giverRecipientDTOs { get; set; }
        public List<GiverDetailDTO> GiverDetailDTO { get; set; }
        public List<GiverAttachmentDTO> GiverAttachmentDTO { get; set; }
    }
}

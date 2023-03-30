using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOClass
{
    public class GiverRecipientDTO
    {
        public int GiverRecipientId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int CounterpartyId { get; set; }

        public string Title { get; set; } = null!;

        public int PersonTypeId { get; set; }

        public int GiftCost { get; set; }

        public int EntCost { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTimeOffset CreatedOn { get; set; }

        public int GiverId { get; set; }

        public string Email { get; set; } = null!;

    }
}

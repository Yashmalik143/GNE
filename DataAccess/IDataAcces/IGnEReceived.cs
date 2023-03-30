using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDataAcces
{
    public interface IGnEReceived
    {
        public Task<string> CurrentGnEId();
        public int ReceiverForm(ReceiverModel model);
        public Task<string> ReceiverRecipint(ReceiverRecipient recipient);
        public Task<string> ReceiverRecipintList(List<ReceiverRecipient> reciverRecipients, int reciverId);
        public Task<string> ReceiverDetails(ReceiverDetail detail);
        public Task<string> ReceiverAttachments(ReceiverAttachment giverAttachment);
    }
}

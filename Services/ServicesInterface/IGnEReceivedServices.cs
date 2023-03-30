using DataAccess.Entity;
using Services.DTOClass;

namespace Services.ServicesInterface
{
    public interface IGnEReceivedServices
    {
        public Task<string> CurrentGnEId();
        public Task<string> ReceiveForm(ReceiverMaster model);
        public Task<string> ReceiverRecipient(ReceiverRecipientDTO recipientDTO);
    }

    
}

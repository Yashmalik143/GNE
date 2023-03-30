using AutoMapper;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Services.DTOClass;
using Services.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepo
{
    public class GnEReveicedServices : IGnEReceivedServices
    {
        private readonly IGnEReceived _received;
        private readonly IMapper _mapper;
        public GnEReveicedServices(IGnEReceived received,IMapper mapper)
        {
            _received = received;
            _mapper = mapper;
        }

        public Task<string> CurrentGnEId()
        {
            throw new NotImplementedException();
        }

        public async Task<string> ReceiveForm(ReceiverMaster model)
        {
            var m1 = model.ReceiverModelDTO;

            List<ReceiverRecipientDTO> receiverRecipients = model.ReceiverRecipientDTO.ToList();

            var receiverRecipientList = _mapper.Map<List<ReceiverRecipientDTO>, List<ReceiverRecipient>>(receiverRecipients);
            var receiverDetails = _mapper.Map<ReceiverDetailsDTO, ReceiverDetail>(model.ReceiverDetailDTO);
            var receiverAttachments = _mapper.Map<ReceiverAttachmentDTO, ReceiverAttachment>(model.ReceiverAttachmentDTO);
            var receiver = _mapper.Map<ReceiverModelDTO, ReceiverModel>(m1);
            var form = _received.ReceiverForm(receiver);

            receiverDetails.ReceiverId = form;
            _received.ReceiverDetails(receiverDetails);
            receiverAttachments.ReceiverId = form;
            _received.ReceiverAttachments(receiverAttachments);
            _received.ReceiverRecipintList(receiverRecipientList, form);


            return "Form Submitted.....";
        }



        public Task<string> ReceiverRecipient(ReceiverRecipientDTO recipientDTO)
        {
            var rec = _mapper.Map<ReceiverRecipientDTO, ReceiverRecipient>(recipientDTO);
            return _received.ReceiverRecipint(rec);
        }

      
    }
}

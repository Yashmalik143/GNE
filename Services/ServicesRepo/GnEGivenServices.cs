using AutoMapper;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Services.DTOClass;
using Services.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepo
{
    public class GnEGivenServices : IGnEGivenServices
    {
        private readonly IGnEGiven _given;
        private readonly IMapper _mapper;
        public GnEGivenServices(IGnEGiven given,IMapper mapper)
        {
            _given = given;
            _mapper = mapper;
        }
        public Task<string> CurrentGnEId()
        {
            var code = _given.CurrentGnEId();
            return code;
        }

        public async Task<GivenMasterDTO> GetGiver(int Id)
        {
            var ab = _given.GetModel(Id);
            var giverModel = _mapper.Map<GiverModel, GiverDTO>(ab.Result);
            var giverAttachment = _mapper.Map<List<GiverAttachment>,List<GiverAttachmentDTO>>(ab.Result.GiverAttachments.ToList());
           var giverDetails = _mapper.Map<List<GivenDetail>, List<GiverDetailDTO>>(ab.Result.GivenDetails.ToList());
            var giverRecipients = _mapper.Map<List<GiverRecipient>, List<GiverRecipientDTO>>(ab.Result.GiverRecipients.ToList());

            GivenMasterDTO givenMaster = new GivenMasterDTO();
            givenMaster.GiverAttachmentDTO = giverAttachment;
            givenMaster.giverRecipientDTOs = giverRecipients;
            givenMaster.GiverDTO = giverModel;
            givenMaster.GiverDetailDTO = giverDetails;
            return givenMaster;
        }

        public Task<GiverModel> GetModel(int Id)
        {
            var ab = _given.GetModel(Id);
            return ab;

        }

        public async Task<string> GivenForm(GivenMasterDTO model)
        {
           
            List<GiverRecipientDTO> giverRecipients = model.giverRecipientDTOs.ToList();

            var giverRecipientList = _mapper.Map<List<GiverRecipientDTO>, List<GiverRecipient>>(model.giverRecipientDTOs.ToList());
            var giverDetails = _mapper.Map<List<GiverDetailDTO>, List<GivenDetail>>(model.GiverDetailDTO.ToList());
            var giverAttachments = _mapper.Map<List<GiverAttachmentDTO>, List<GiverAttachment>>(model.GiverAttachmentDTO.ToList());
            var giver = _mapper.Map<GiverDTO, GiverModel>(model.GiverDTO);
            giver.GiverRecipients = giverRecipientList; 
            giver.GiverAttachments = giverAttachments;
            giver.GivenDetails = giverDetails;
           _given.GivenForm(giver);

            

                return "Form Submitted.....";
          
        }

        public Task<string> GiverRecipient(GiverRecipientDTO recipientDTO)
        {
            var rec = _mapper.Map<GiverRecipientDTO, GiverRecipient>(recipientDTO);
           return _given.GivenRecipint(rec);
        }

        public Task<List<GiverModel>> GnEGiven()
        {
           var allData= _given.GnEGivenAll();
                return allData;
        }
    }
}

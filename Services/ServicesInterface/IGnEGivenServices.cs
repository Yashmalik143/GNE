using DataAccess.Entity;
using Services.DTOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesInterface
{
    public interface IGnEGivenServices
    {
        public Task<string> CurrentGnEId();
        public Task<List<GiverModel>> GnEGiven();
        public Task<string> GivenForm(GivenMasterDTO model);
        public Task<string> GiverRecipient(GiverRecipientDTO recipientDTO);
        public Task<GivenMasterDTO> GetGiver(int Id);

        public Task<GiverModel> GetModel(int Id);

      
    }
}

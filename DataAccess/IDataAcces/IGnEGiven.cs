using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDataAcces
{
    public interface IGnEGiven
    {
        public Task<string> CurrentGnEId();
        public Task<List<GiverModel>> GnEGivenAll();
        public int GivenForm(GiverModel model);
        public Task<string> GivenRecipint(GiverRecipient recipient);
        public Task<string> GivenRecipintList(List<GiverRecipient> giverRecipients,int giverId);
        public Task<string> GivenDetails(GivenDetail detail);
        public Task<string> GivenAttachments(GiverAttachment giverAttachment);
        public Task<List<GiverAttachment>> GetAttachment(int id);
        public Task<GiverModel> GetModel(int id);
        public Task<List<GivenDetail>> GetDetail(int id);
        public List<GiverRecipient> GetRecipients(int id);
    }
}

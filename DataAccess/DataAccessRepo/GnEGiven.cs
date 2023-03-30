
using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.Helper;
using DataAccess.IDataAcces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessRepo
{
    public class GnEGiven : IGnEGiven
    {
        private readonly Context.GneProjectContext _Context;
        private readonly IHelper helper;
        public GnEGiven(Context.GneProjectContext context,IHelper helper)
        {
            this.helper = helper;
            _Context = context;
        }
        public async Task<string> CurrentGnEId()
        {
            return helper.GenrateFormCode();
        }

        public async Task<List<GiverAttachment>> GetAttachment(int id)
        {
            return await _Context.GiverAttachments.Where(x => x.GiverId == id).ToListAsync();
        }

        public async Task<List<GivenDetail>> GetDetail(int id)
        {
            return await _Context.GivenDetails.Where(x => x.GivenId == id).ToListAsync();
        }

        public async Task<GiverModel> GetModel(int id)
        {
            return await _Context.GiverModels
                .Include(x => x.GiverRecipients)
                .Include(x => x.GivenDetails)
                .Include(x => x.GiverAttachments)
                .OrderBy(x => x.GiverModelId)
                .LastOrDefaultAsync();
            //.FirstOrDefaultAsync(x => x.GiverModelId == id); 
        }

        public List<GiverRecipient> GetRecipients(int id)
        {
            var recipients = _Context.GiverRecipients.Where(x => x.GiverId == id).ToList();
            return recipients;
        }

        public async Task<string> GivenAttachments(GiverAttachment giverAttachment)
        {
            _Context.GiverAttachments.Add(giverAttachment);
            _Context.SaveChanges();
            return "Attachment Added";
        }

        public async Task<string> GivenDetails(GivenDetail detail)
        {
            _Context.GivenDetails.Add(detail);
            _Context.SaveChanges();
            return "details added";

        }

        public int GivenForm(GiverModel model)
        {
            try
            {
              
                    model.FormCode = helper.GenrateFormCode();
                    model.ComplienceStatus = "Pending";
                    model.BussinessStatus = "Pending";
                    model.GivenDate = DateTime.Now;
                    model.CreatedOn= DateTimeOffset.Now;
                    model.CreatedBy = "system";
                    //var curr= _Context.Currencies.FirstOrDefault(x => x.CurrencyId == model.CurrencyId);
                    //  model.Currency = curr;
                    _Context.GiverModels.Add(model);
                    _Context.SaveChanges();
                    return (model.GiverModelId);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GivenRecipint(GiverRecipient recipient)
        {
            _Context.GiverRecipients.Add(recipient);
            _Context.SaveChangesAsync();
            return "Added Succesfully";
        }

        public async Task<string> GivenRecipintList(List<GiverRecipient> giverRecipients, int giverId)
        {
            foreach (var a in giverRecipients)
            {
                a.GiverId = giverId;
                _Context.GiverRecipients.Add(a);
            }
            _Context.SaveChangesAsync();
            return "recipients added";
        }

        public async Task<List<GiverModel>> GnEGivenAll()

        {
            return _Context
                 .GiverModels
                 //.Include(x => x.GiverRecipients)
                 //.Include(x => x.GivenDetails)
                 //.Include(x => x.GiverAttachments)
                 .ToList();
        }
    }
}
//string code = $"GE-{form.CreationDate.ToString("yyyyMMdd")}-{form.Id.ToString().PadLeft(9, '0')}";
//form.Code = code;
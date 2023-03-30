using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessRepo
{

    public class GnEReceived : IGnEReceived
    {
        private readonly GneProjectContext _context;
      //  private readonly Ihelper _helper;
        public GnEReceived(GneProjectContext context)
        { 
            _context = context;
        //    _helper = helper;
        }
        public Task<string> CurrentGnEId()
        {
          //  var data = _helper.Code();
            return Task.FromResult("data");
        }

        public async Task<string> ReceiverAttachments(ReceiverAttachment giverAttachment)
        {
            await _context.ReceiverAttachments.AddAsync(giverAttachment);
            await _context.SaveChangesAsync();
            return "Attachment Added...";
        }

        public async Task<string> ReceiverDetails(ReceiverDetail detail)
        {
            await _context.ReceiverDetails.AddAsync(detail);
            await _context.SaveChangesAsync();
            return "Details Added...";
        }

        public int ReceiverForm(ReceiverModel model)
        {
            var uniqueFormCode = _context.ReceiverModels.Where(x => x.FormCode == model.FormCode).FirstOrDefault();
            if (uniqueFormCode == null)
            {
                var currencyId = _context.Currencies.FirstOrDefault(x => x.CurrencyId == model.CurrencyId);
                model.Currency = currencyId;
                _context.ReceiverModels.Add(model);
                _context.SaveChanges();
                return (model.ReceiverId);

            }
            return (uniqueFormCode.ReceiverId);
        }


        public async Task<string> ReceiverRecipint(ReceiverRecipient recipient)
        {
            await _context.ReceiverRecipients.AddAsync(recipient);
            await _context.SaveChangesAsync();
            return "Receiver Added";
        }

        public async Task<string> ReceiverRecipintList(List<ReceiverRecipient> reciverRecipients, int reciverId)
        {
            foreach (var a in reciverRecipients)
            {
                a.ReceiverId = reciverId;
                _context.ReceiverRecipients.Add(a);
            }
            _context.SaveChanges();
            return "recipients added";
        }
    }




    //public async Task<string> ReceiverRecipientForm(ReceiverRecipient recipient)
    //    {
    //        try
    //        {


    //        }
    //        catch (Exception exe )
    //        {

    //            throw new Exception(exe.Message);
    //        }
    //    }
    //}
}

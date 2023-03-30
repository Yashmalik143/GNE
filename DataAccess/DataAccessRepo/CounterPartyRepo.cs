
using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.IDataAcces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccessRepo
{

    public class CounterPartyRepo : ICounterParty
    {
        private readonly Context.GneProjectContext _context;
        public CounterPartyRepo(Context.GneProjectContext context)
        {
            _context = context;
        }
        public async Task<string> EditOrApproveCounterParty(CounterParty counterParty)
        {

            var exisitingData = await _context.CounterParties.FirstOrDefaultAsync(x => x.PartyName == counterParty.PartyName);
            if (exisitingData == null)
            {
                var newCounterParty = new CounterParty
                {
                    PartyName = counterParty.PartyName,
                    Status = counterParty.Status,

                };
                await _context.CounterParties.AddAsync(newCounterParty);
            }
            else
            {

                exisitingData.Status = counterParty.Status;
            }

            await _context.SaveChangesAsync();
            return (counterParty.CounterPartyId == 0 ? "Added Succesfully......:)" : "Updated Successfully");


        }

        public async Task<List<CounterParty>> GetListOfCounter()
        {
            return await _context.CounterParties.ToListAsync();

        }
    }
}

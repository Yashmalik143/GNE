using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public class HelperRepo : IHelper
    {
        private readonly GneProjectContext _Context;

        public HelperRepo(GneProjectContext context)
        {
            _Context = context;
        }
        public string GenrateFormCode()
        {
            string input =  _Context.GiverModels.OrderByDescending(x => x.GiverModelId).FirstOrDefault().FormCode;
            
            string inputRec = _Context.ReceiverModels.OrderByDescending(x => x.ReceiverId).FirstOrDefault().FormCode;
            //string input = "10,20,30";

            if (input == null)
            {

                string[] partsRec = inputRec.Split('-');

                string secondPart = int.Parse(partsRec[1]) + 1.ToString();

                string output = secondPart.PadLeft(10, '0');

                string finalstring = partsRec[0] + "-" + output;

                return finalstring;
            }
            else if (inputRec == null)
            {
                string[] parts = inputRec.Split('-');


                string secondPart = int.Parse(parts[1]) + 1.ToString();

                string output = secondPart.PadLeft(10, '0');

                string finalstring = parts[0] + "-" + output;

                return finalstring;

            }
            else if (input == null || inputRec == null)
            {
                return "GE-000000001";
            }
            else
            {
                string[] partsRec = inputRec.Split('-');
                string[] parts = input.Split('-');

                        
                int partsInt = int.Parse(parts[1]);
                int partsRecInt = int.Parse(partsRec[1]);

                        if (partsInt > partsRecInt) {



                            int secondPart = partsInt + 1;

                            string output = secondPart.ToString("D9");

                            string finalstring = parts[0] + "-" + output;

                            return finalstring;
                        }
                        else
                        {
                            int secondPart = partsRecInt + 1;

                            string output = secondPart.ToString("D9");

                            string finalstring = partsRec[0] + "-" + output;

                            return finalstring;

                        }
                    }
        }
    }
}

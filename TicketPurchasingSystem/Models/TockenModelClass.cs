using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketPurchasingSystem.Models
{
    public class TockenModelClass
    {
        RailwayDBContext railwayDbContexts = new RailwayDBContext();

        [ReadOnly(true)]
        [HiddenInput(DisplayValue = false)]
        public int TokenID { get; set; }

        [Required(ErrorMessage ="Token Number is Required")]
        [DisplayName("Enter Token Number")]
        public string TokenNumber { get; set; }

        public bool CheckTokenNumber(int TokenNumber)
        {
            Token inputToken = railwayDbContexts.Token.FirstOrDefault(w => w.TokenNumber == TokenNumber);
            if(inputToken == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RemoveToken(int TokenNumber)
        {
            Token inputToken = railwayDbContexts.Token.FirstOrDefault(w => w.TokenNumber == TokenNumber);
            railwayDbContexts.Token.Remove(inputToken);
            railwayDbContexts.SaveChanges();
        }
    }
}
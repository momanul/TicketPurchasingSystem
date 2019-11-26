using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketPurchasingSystem.Models
{
    public class TicketConfirmField
    {
        [Required]
        [DisplayName("Total Number Of Seat:")]
        [Range(1, 6)]
        public int NumberOfSeat { get; set; }
        [Required]
        [DisplayName("Seat's Number:")]
        public string SeatNumber { get; set; }
        [Required]
        [DisplayName("Bogy Name:")]
        public string BogyName { get; set; }
    }
}
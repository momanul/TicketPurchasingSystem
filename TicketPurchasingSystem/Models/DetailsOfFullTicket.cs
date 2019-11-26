using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketPurchasingSystem.Models
{
    public class DetailsOfFullTicket
    {
        public string PersonName { get; set; }
        public string PersonFathersName { get; set; }
        public string PersonMothersName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string PersonAddress { get; set; }
        public string JourneyDate { get; set; }
        [DisplayName("Station Form")]
        public string JourneyStart { get; set; }
        [DisplayName("Station To")]
        public string JourneyEnd { get; set; }
        public string CoatchType { get; set; }
        public int TokenNumber { get; set; }
        [DisplayName("Seat's Number")]
        public string SeatNumber { get; set; }
        public string BogyName { get; set; }
        [DisplayName("Total Number Of Seat")]
        public int NumberOfSeat { get; set; }
        public string TimeOfJourney { get; set; }
    }
}
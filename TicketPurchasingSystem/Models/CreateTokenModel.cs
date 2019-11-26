using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketPurchasingSystem.Models;

namespace TicketPurchasingSystem.Models
{
    public class CreateTokenModel : Controller
    {
        Random random = new Random();
        int tokenNumber;
        RailwayDBContext railwayDbContexts = new RailwayDBContext();
        [DisplayName("Journey Date")]
        [Required]
        public DateTime JourneyDate { get; set; }
        [DisplayName("Station To")]
        [Required]
        public string JourneyStart { get; set; }
        [Required]
        [DisplayName("Station Form")]
        public string JourneyEnd { get; set; }
        [Required]
        public string CoatchType { get; set; }
        [Required]
        public string TimeOfJourney { get; set; }
        public int TokenNumber { get; set; }
        public int personID { get; set; }
        int ID;
        public void insertData(CreateTokenModel createTokenModel)
        {
            tokenNumber = random.Next(10000000, 20000000);
            Journey journey = new Journey();
            Token token = new Token();
            journey.JourneyDate = createTokenModel.JourneyDate;
            journey.JourneyStart = createTokenModel.JourneyStart;
            journey.JourneyEnd = createTokenModel.JourneyEnd;
            journey.CoatchType = createTokenModel.CoatchType;
            journey.TimeOfJourney = createTokenModel.TimeOfJourney;
            journey.TokenNumber = tokenNumber;
            token.TokenNumber = tokenNumber;
            journey.PersonID = createTokenModel.personID;
            ID = createTokenModel.personID;
            railwayDbContexts.Token.Add(token);
            railwayDbContexts.SaveChanges();
            railwayDbContexts.Journey.Add(journey);
            railwayDbContexts.SaveChanges();
            //UpdateTicketStatus(journey.CoatchType);
        }
        public Journey GetDetails()
        {
            Journey journey = railwayDbContexts.Journey.FirstOrDefault(y => y.TokenNumber == tokenNumber);
            return journey;
        }
        public bool isAlreadyPurchseToday(DateTime journeyData, int personID)
        {
            var shortDate = journeyData.ToShortDateString();
            DateTime s;
            var person = railwayDbContexts.Journey.Where(a => a.PersonID == personID).Select(a=>a.JourneyDate).ToList();
            foreach(var i in person)
            {
                s = Convert.ToDateTime(i);
                var d = s.ToShortDateString();
                if(shortDate == d)
                {
                    return false;
                }
            }
            return true;
        }
        public void UpdateTicketStatus(string CoatchType)
        {
            switch (CoatchType)
            {
                case "AC":
                    Session["AvailableACTicket"] = Convert.ToInt32(Session["AvailableACTicket"]) - 1;
                    Session["NumberOfACPendingTicket"] = Convert.ToInt32(Session["NumberOfACPendingTicket"]) + 1;
                    break; 
                case "S_CHAIR":
                    Session["AvailableS_ChairTicket"] = Convert.ToInt32(Session["AvailableS_ChairTicket"]) - 1;
                    Session["NumberOfS_ChairPendingTicket"] = Convert.ToInt32(Session["NumberOfS_ChairPendingTicket"]) + 1;
                    break;

            }
        }
    }
    public class TicketDetails
    {
        public List<TicketDetails> ticketDetails;
        public DateTime JourneyDate { get; set; }
        public string StationToStation { get; set; }
        public string CoatchType { get; set; }
        public int TotalAvailableTicket { get; set; }
	    public int NumberOfPendingTicket { get; set; }
	    public int NumberOfSoldTicket { get; set; }
	    public string TrainDeparterTime { get; set; }
        public List<TicketDetails> GetTicketDetails
        {
            get
            {
                ticketDetails = new List<TicketDetails>()
                {
                    new TicketDetails{ JourneyDate = DateTime.Now, CoatchType = "AC", NumberOfPendingTicket = 0, NumberOfSoldTicket = 0,
                    StationToStation = "Dhaka To Rajshahi", TotalAvailableTicket = 200, TrainDeparterTime = DateTime.Now.AddHours(6).ToShortTimeString()},
                    new TicketDetails{ JourneyDate = DateTime.Now, CoatchType = "S_CHAIR", NumberOfPendingTicket = 0, NumberOfSoldTicket = 0,
                    StationToStation = "Dhaka To Rajshahi", TotalAvailableTicket = 1000, TrainDeparterTime = DateTime.Now.AddHours(6).ToShortTimeString()}
                };
                return ticketDetails;
            }
        }
        //public TicketDetails()
        //{
        //    ticketDetails = new List<TicketDetails>()
        //    {
        //        new TicketDetails{ JourneyDate = DateTime.Now, CoatchType = "AC", NumberOfPendingTicket = 0, NumberOfSoldTicket = 0,
        //        StationToStation = "Dhaka To Rajshahi", TotalAvailableTicket = 200, TrainDeparterTime = DateTime.Now.AddHours(6).ToShortTimeString()},
        //        new TicketDetails{ JourneyDate = DateTime.Now, CoatchType = "S_CHAIR", NumberOfPendingTicket = 0, NumberOfSoldTicket = 0,
        //        StationToStation = "Dhaka To Rajshahi", TotalAvailableTicket = 1000, TrainDeparterTime = DateTime.Now.AddHours(6).ToShortTimeString()}
        //    };
        //}
    }
}
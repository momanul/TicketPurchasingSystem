using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketPurchasingSystem.Models;

namespace TicketPurchasingSystem.Controllers
{
    public class HomeController : Controller
    {
        TockenModelClass tockenModelClass = new TockenModelClass();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            TicketDetails details = new TicketDetails();
            var g = details.GetTicketDetails;
            return View(g);
        }
        [HttpGet]
        public ActionResult PurchageTicket()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PurchageTicket(string TokenNumber)
        {
            int T;
            Int32.TryParse(TokenNumber, out T);
            if (T == 0)
            {
                ModelState.AddModelError("TokenNumber", "Please Enter Valid Token Number");
                return View("PurchageTicket");
            }
            else
            {
                bool result = tockenModelClass.CheckTokenNumber(T);
                if (result == true)
                {
                    tockenModelClass.RemoveToken(T);
                    return RedirectToActionPermanent("PurchageTicketConfirm", "Home");
                }
                else
                {
                    ModelState.AddModelError("TokenNumber", "Please Enter a Generated Token Number");
                    return View("PurchageTicket");
                }
            }
        }
        public ActionResult PurchageTicketConfirm()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult PurchageTicketConfirm(TicketConfirmField TicketConfirmField)
        {
            if (ModelState.IsValid)
            {
                Session["TicketConfirmField"] = TicketConfirmField;
                return RedirectToActionPermanent("YourTrainTicket");
            }
            return View("PurchageTicketConfirm");
        }
        public ActionResult YourTrainTicket()
        {
            DetailsOfFullTicket detailsOfFullTicket = GetTicketDetails();
            UpdateTicketStatusPendingToSold(detailsOfFullTicket.CoatchType);
            return View(detailsOfFullTicket);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public void UpdateTicketStatusPendingToSold(string CoatchType)
        {
            switch (CoatchType)
            {
                case "AC":
                    Session["NumberOfACPendingTicket"] = Convert.ToInt32(Session["NumberOfACPendingTicket"]) - 1;
                    Session["NumberOfACSoldTicket"] = Convert.ToInt32(Session["NumberOfACSoldTicket"]) + 1;
                    break;
                case "S_CHAIR":
                    Session["NumberOfS_ChairPendingTicket"] = Convert.ToInt32(Session["NumberOfS_ChairPendingTicket"]) - 1;
                    Session["NumberOfS_ChairSoldTicket"] = Convert.ToInt32(Session["NumberOfS_ChairSoldTicket"]) + 1;
                    break;

            }
        }
        public DetailsOfFullTicket GetTicketDetails()
        {
            DetailsOfFullTicket detailsOfFullTicket = new DetailsOfFullTicket();
            CreateTokenModel tokenDetails = (CreateTokenModel)Session["CreateToken"];
            Person personDetsils = (Person)Session["Persons"];
            TicketConfirmField ticketConfirmField = (TicketConfirmField)Session["TicketConfirmField"];

            detailsOfFullTicket.PersonName = personDetsils.PersonName;
            detailsOfFullTicket.PersonFathersName = personDetsils.PersonFathersName;
            detailsOfFullTicket.PersonAddress = personDetsils.PersonAddress;
            detailsOfFullTicket.CoatchType = tokenDetails.CoatchType;
            detailsOfFullTicket.BogyName = ticketConfirmField.BogyName;
            detailsOfFullTicket.SeatNumber = ticketConfirmField.SeatNumber;
            detailsOfFullTicket.NumberOfSeat = ticketConfirmField.NumberOfSeat;
            detailsOfFullTicket.JourneyStart = tokenDetails.JourneyStart;
            detailsOfFullTicket.JourneyEnd = tokenDetails.JourneyEnd;
            detailsOfFullTicket.JourneyDate = tokenDetails.JourneyDate.ToShortDateString();
            detailsOfFullTicket.TimeOfJourney = tokenDetails.TimeOfJourney;

            return detailsOfFullTicket;
        }
    }
}
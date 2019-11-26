using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TicketPurchasingSystem.Models
{
    public class PersonsModel
    {

        RailwayDBContext railwayDbContexts = new RailwayDBContext();
        [DisplayName("Person ID")]
        public int PersonID { get; set; }
        [DisplayName("Person's Name")]
        public string PersonName { get; set; }
        [DisplayName("Person's Fathers Name")]
        public string PersonFathersName { get; set; }
        [DisplayName("Person's Mothers Name")]
        public string PersonMothersName { get; set; }
        [DisplayName("Date Of Birth")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [DisplayName("Person's Address")]
        public string PersonAddress { get; set; }
        public PersonsModel GetPersonalDetails(int PersonID)
        {
            PersonsModel personsModel = new PersonsModel();
            Person person = railwayDbContexts.Person.FirstOrDefault(y => y.PersonID == PersonID);
            if (person == null)
            {
                return null;

            }
            else
            {
                personsModel.PersonID = person.PersonID;
                personsModel.PersonName = person.PersonName;
                personsModel.PersonFathersName = person.PersonFathersName;
                personsModel.PersonMothersName = person.PersonMothersName;
                personsModel.DateOfBirth = person.DateOfBirth;
                personsModel.PersonAddress = person.PersonAddress;
                return personsModel;
            }            
        }
    }
}
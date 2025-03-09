namespace EventManagement.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string EventTitle { get; set; } // Name's Baptisim 
        public string EventDescription { get; set; } 

        public string EventOrganizer {  get; set; }

        public DateOnly EventDate {  get; set; }

        public TimeOnly EventTime { get; set; }

        public DateTime EndDate { get; set; }
        public string EventPlace { get; set; }
        public string Category { get; set; } //wedding //memorial //inaguration 

        public int Attendees { get; set; } // Number 

        public DateTime RegistrationDeadline { get; set; }  

        public decimal RegistrationFee { get; set; }

        public int Capacity { get; set; }

        public string ImageUrl { get; set; }


    }
}

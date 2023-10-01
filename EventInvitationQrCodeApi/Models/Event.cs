namespace EventInvitationQrCodeApi.Models
{
    public class Event
    {


        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }


        public ICollection<User> Users { get; set; } = new List<User>();

        public List<UserEvent> UserEvent { get; set; }



    }
}

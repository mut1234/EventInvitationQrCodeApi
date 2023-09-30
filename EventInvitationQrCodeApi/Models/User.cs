using Microsoft.Extensions.Logging;

namespace EventInvitationQrCodeApi.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime UserDateAddedToSystem { get; set; }// the date that when client added to system

        public ICollection<Event> Event { get; set; } = new List<Event>();


        public ICollection<QrCode2> QrCode2 { get; set; } = new List<QrCode2>();


        public List<UserEvent> UserEvent { get; set; }



    }
}

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


        public ICollection<Event> Events { get; set; } = new List<Event>();


        public ICollection<QrCode> QrCode { get; set; } = new List<QrCode>();


        public List<UserEvent> UserEvent { get; set; }




    }
}

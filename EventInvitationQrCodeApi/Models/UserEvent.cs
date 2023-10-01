﻿namespace EventInvitationQrCodeApi.Models
{
    public class UserEvent
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        public DateTime DateUserAddedToEvent { get; set; }


    }
}

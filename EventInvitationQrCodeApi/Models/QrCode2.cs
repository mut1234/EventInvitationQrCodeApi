namespace EventInvitationQrCodeApi.Models
{
    public class QrCode2
    {
        public int QrCodeId { get; set; }

        public string QrCodeString { get; set; } = string.Empty;

        public User User { get; set; }

        public int QrCode_User_Id { get; set; }

    }
}

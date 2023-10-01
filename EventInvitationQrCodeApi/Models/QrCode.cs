namespace EventInvitationQrCodeApi.Models
{
    public class QrCode
    {
        public int QrCodeId { get; set; }

        public string UserQrCodeString { get; set; } = string.Empty;

        public User User { get; set; } = null!;

        public int QrCode_User_Id { get; set; }


    }
}

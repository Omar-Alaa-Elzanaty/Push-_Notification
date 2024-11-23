namespace PushNotification.API
{
    public class NotificationDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string FcmToken { get; set; }
    }
}

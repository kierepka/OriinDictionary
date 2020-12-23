namespace OriinDic.Store.Notifications
{
    public record NotificationsState
    {
        public string Notification { get; } = string.Empty;

        public NotificationsState(string notification)
        {
            Notification = notification;
        }

    }
}

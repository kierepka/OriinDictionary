namespace OriinDic.Store.Notifications
{
    public record NotificationAction
    {
        public string Text { get; init; } = string.Empty;

        public NotificationAction(string text)
        {
            Text = text;
        }
    }
}

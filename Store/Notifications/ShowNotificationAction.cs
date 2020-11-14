using System;

namespace OriinDic.Store.Notifications
{
    public class ShowNotificationAction
    {
        public string Text { get; init; } = string.Empty;

        public ShowNotificationAction(string text)
        {

            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            Text = text;
        }
    }
}

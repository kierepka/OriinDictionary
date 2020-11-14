using System;

namespace OriinDic.Models
{
    public class Notification
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Text { get; private set; } = string.Empty;

        [Obsolete]
        public Notification() { }

        public Notification(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            Text = text;
        }
    }
}

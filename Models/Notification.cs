using System;

namespace OriinDic.Models
{
    // ReSharper disable once UnusedType.Global
    public class Notification
    {
        // ReSharper disable once UnusedMember.Global
        public Guid Id { get; set; } = Guid.NewGuid();
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        private string Text { get; set; }

        
        public Notification(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            Text = text;
            Text = text;
        }
    }
}

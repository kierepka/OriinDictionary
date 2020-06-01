using System;

namespace OriinDic.Store.Notifications
{
  public class ShowNotificationAction
  {
    public string Text { get; }

    public ShowNotificationAction(string text)
    {

      if (string.IsNullOrWhiteSpace(text))
        throw new ArgumentNullException(nameof(text));

      Text = text;
    }
  }
}

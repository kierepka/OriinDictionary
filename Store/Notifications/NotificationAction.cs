using Blazorise.Snackbar;

namespace OriinDic.Store.Notifications
{
    public record NotificationAction
    {
        public string Text { get; } = string.Empty;
        public SnackbarColor SnackbarColor { get; } = SnackbarColor.Success;

        public NotificationAction(string text, SnackbarColor snackbarColor)
        {
            Text = text;
            SnackbarColor = snackbarColor;
        }
    }
}

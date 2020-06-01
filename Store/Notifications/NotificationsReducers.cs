using Fluxor;

namespace OriinDic.Store.Notifications
{
  public static class NotificationsReducers
  {
    [ReducerMethod]
    public static NotificationsState ReduceShowNotificationAction(
      NotificationsState state, ShowNotificationAction action) => new NotificationsState(action.Text);

  }
}

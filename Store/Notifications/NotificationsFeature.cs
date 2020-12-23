using Fluxor;

namespace OriinDic.Store.Notifications
{
  public class NotificationsFeature : Feature<NotificationsState>
  {
    public override string GetName() => "Notifications";
    protected override NotificationsState GetInitialState() => new(string.Empty);
  }
}

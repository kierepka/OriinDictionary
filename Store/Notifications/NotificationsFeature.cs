using Fluxor;

namespace OriinDictionary7.Store.Notifications;

public class NotificationsFeature : Feature<NotificationsState>
{
    public override string GetName() => "Notifications";
    protected override NotificationsState GetInitialState() => new(string.Empty);
}

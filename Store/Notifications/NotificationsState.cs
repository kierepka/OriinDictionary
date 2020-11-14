using System;
using System.Collections.Generic;
using System.Linq;

using OriinDic.Models;

namespace OriinDic.Store.Notifications
{
    public class NotificationsState
    {
        public string Notification { get; init; } = string.Empty;

        public static NotificationsState EmptyState =
            new NotificationsState(string.Empty);

        public NotificationsState(string notification)
        {
            Notification = notification;
        }

    }
}

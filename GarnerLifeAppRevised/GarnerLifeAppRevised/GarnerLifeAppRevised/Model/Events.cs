using Plugin.PushNotification;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarnerLifeAppRevised.Model
{
    class Events
    {
        /// <summary>
        /// Event triggered when token is refreshed
        /// </summary>
        event PushNotificationTokenEventHandler OnTokenRefresh;

        /// <summary>
        /// Event triggered when a notification is received
        /// </summary>
        event PushNotificationResponseEventHandler OnNotificationReceived;

        /// <summary>
        /// Event triggered when a notification is opened
        /// </summary>
        event PushNotificationResponseEventHandler OnNotificationOpened;

        /// <summary>
        /// Event triggered when a notification is opened by tapping an action
        /// </summary>
        event PushNotificationResponseEventHandler OnNotificationAction;

        /// <summary>
        /// Event triggered when a notification is deleted (Android Only)
        /// </summary>
        event PushNotificationDataEventHandler OnNotificationDeleted;

        /// <summary>
        /// Event triggered when there's an error
        /// </summary>
        event PushNotificationErrorEventHandler OnNotificationError;
    }
}

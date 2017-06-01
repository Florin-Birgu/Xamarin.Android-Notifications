using Android.App;
using Android.Content;

namespace Notifications
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var title = "Hello world!";
            var message = "Checkout this notification";

            Intent backIntent = new Intent(context, typeof(MainActivity));
            backIntent.SetFlags(ActivityFlags.NewTask);
            
            //The activity opened when we click the notification is SecondActivity
            //Feel free to change it to you own activity
            var resultIntent = new Intent(context, typeof(SecondActivity));

            PendingIntent pending = PendingIntent.GetActivities(context, 0,
                new Intent[] { backIntent, resultIntent },
                PendingIntentFlags.OneShot);

            var builder =
                new Notification.Builder(context)
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetAutoCancel(true)
                    .SetSmallIcon(Resource.Drawable.Icon)
                    .SetDefaults(NotificationDefaults.All);

            builder.SetContentIntent(pending);
            var notification = builder.Build();
            var manager = NotificationManager.FromContext(context);
            manager.Notify(1331, notification);

        }
    }
}
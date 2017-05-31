using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Notifications
{
    [Activity(Label = "Notifications", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Intent alarmIntent = new Intent(this, typeof(AlarmReceiver));
            PendingIntent pending = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
            PendingIntent pendingIntent;

            alarmManager.SetRepeating(AlarmType.RtcWakeup, BootReceiver.FirstReminder(), BootReceiver.reminderInterval, pending);
            pendingIntent = PendingIntent.GetBroadcast(this, 0, alarmIntent, 0);

        }
    }
}


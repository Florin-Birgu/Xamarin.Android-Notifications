using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Notifications
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class BootReceiver : BroadcastReceiver
    {
        public static int daysRange = 1;
        public static long reminderInterval =  60 * 1000;
        public static long FirstReminder()
        {
            Java.Util.Calendar calendar = Java.Util.Calendar.Instance;
            //calendar.Add(Java.Util.CalendarField.Date, 3);
            calendar.Set(Java.Util.CalendarField.HourOfDay, 20);
            calendar.Set(Java.Util.CalendarField.Minute, 06);
            calendar.Set(Java.Util.CalendarField.Second, 00);
            return calendar.TimeInMillis;
        }
        public override void OnReceive(Context context, Intent intent)
        {
            Console.WriteLine("BootReceiver: OnReceive");
            var alarmIntent = new Intent(context, typeof(AlarmReceiver));
            var pending = PendingIntent.GetBroadcast(context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);


            alarmManager.SetRepeating(AlarmType.RtcWakeup, FirstReminder(), reminderInterval, pending);
            PendingIntent pendingIntent;

            pendingIntent = PendingIntent.GetBroadcast(context, 0, alarmIntent, 0);
        }
    }
}
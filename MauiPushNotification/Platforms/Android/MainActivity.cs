using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Plugin.Firebase.CloudMessaging;



namespace MauiPushNotification
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HandleIntent(Intent);
            CreateNotificationChannelIfNeeded();
          
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            HandleIntent(intent);
        }

        private static void HandleIntent(Intent intent)
        {
            //FirebaseCloudMessagingImplementation.OnNewIntent(intent);

            if (intent == null)
            {
                return;
            }

            var url = intent.Extras?.GetString("url");
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri))
            {
                Microsoft.Maui.Controls.Application.Current?.SendOnAppLinkRequestReceived(uri);
            }


            ///* Handle the intent when the app is launched from a notification */
            //if (intent.Extras != null)
            //{
            //    foreach (var key in intent.Extras.KeySet())
            //    {
            //        if (key == "NavigationID")
            //        {
            //            string idValue = intent.Extras.GetString(key);
            //            if (Preferences.ContainsKey("NavigationID"))
            //                Preferences.Remove("NavigationID");

            //            Preferences.Set("NavigationID", idValue);

            //            WeakReferenceMessenger.Default.Send(new PushNotificationReceived("test"));
            //        }
            //    }
            //}
        }

        private void CreateNotificationChannelIfNeeded()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                CreateNotificationChannel();
            }
        }

        private void CreateNotificationChannel()
        {
            var channelId = $"{PackageName}.general";
           // var channelId = $"{PackageName}";
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            var channel = new NotificationChannel(channelId, "General", NotificationImportance.Default);
            notificationManager.CreateNotificationChannel(channel);
            FirebaseCloudMessagingImplementation.ChannelId = channelId;
            
        }
    }
}

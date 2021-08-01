using System.Linq;
using System.Threading.Tasks;
using ami.Model;
using Foundation;
using Realms;
using UIKit;
using UserNotifications;
using Plugin.Connectivity;

namespace ami
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AppDelegate : UIApplicationDelegate
    {
        public static readonly UIStoryboard Storyboard = UIStoryboard.FromName("Main", null);
        public static RealmConfiguration config;

        private UIViewController _initialVc;
        // class-level declarations

        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            //MobileCenter.Start("c6ec1136-de74-40b4-8cb2-6a2da0baea64",
            //    typeof(Analytics), typeof(Crashes));
            //Analytics.SetEnabledAsync(true);
            if(config ==null)
            {
                config = new RealmConfiguration();
                config.ShouldDeleteIfMigrationNeeded = true;
            }
            var realm = GetRealm();
            var setting = realm.All<SettingsModel>().FirstOrDefault();
            if (setting != null && setting.DetectCommandSelection() && NSBundle.MainBundle.PreferredLocalizations[0] == setting.LanguageCode)
            {
                _initialVc = Storyboard.InstantiateViewController("MainTabController");
            }
            else
            {
                realm.Write(() => { realm.RemoveAll();});
                _initialVc = Storyboard.InstantiateViewController("SetupNameViewController");
            }
            Window.RootViewController = _initialVc;

            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Sound, (approved, err) =>
            {
                // Handle approval
            });
            UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        public static Realm GetRealm()
        {
            return Realm.GetInstance(config);
        }
    }
}
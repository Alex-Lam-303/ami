using System;
using System.Threading.Tasks;
using ami.Helper;
using ami.Model;
using Foundation;
using Realms;
using UIKit;

namespace ami.ViewControllers
{
    public partial class LoginViewController : UnhideTextFieldBaseViewController, IErrorHandleViewController
    {
        public LoginViewController(IntPtr handle) : base(handle)
        {
        }


        public void PresentProblemAlert(string msg)
        {
            var realm = AppDelegate.GetRealm();
            realm.Write(() => realm.RemoveAll());
            var okAlertController = UIAlertController.Create("Error", msg, UIAlertControllerStyle.Alert);
            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            // Present Alert
            PresentViewController(okAlertController, true, null);
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ActivateKeyboardDetection(TopConstraint);
            var realm = AppDelegate.GetRealm();
            realm.Write(
                () => { realm.RemoveAll(); }
            );
        }

        partial void LoginSubmit(NSObject sender)
        {
            var email = EmailField.Text;
            var password = SettingsModel.GetStringSha256Hash(PasswordField.Text);
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return;
            var loginTask = CustomerModel.Login(email, password);
            loginTask.ContinueWith(arg => InvokeOnMainThread(() =>
            {
                var setting = new SettingsModel
                {
                    Customer = arg.Result
                };
                var realm = AppDelegate.GetRealm();
                realm.Write(() => { realm.Add(setting); });
                PerformSegue("LoginSegue", this);
            }), TaskContinuationOptions.OnlyOnRanToCompletion);
            RefitErrorProcessing.Process(loginTask, this);
        }
    }
}
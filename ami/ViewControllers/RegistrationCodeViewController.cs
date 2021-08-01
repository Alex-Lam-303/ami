using System;
using System.Linq;
using System.Threading.Tasks;
using ami.Helper;
using ami.Model;
using Foundation;
using Realms;
using UIKit;

namespace ami.ViewControllers
{
    public partial class RegistrationCodeViewController : UnhideTextFieldBaseViewController, IErrorHandleViewController
    {
        public RegistrationCodeViewController(IntPtr handle) : base(handle)
        {
        }

        //and go back
        public void PresentProblemAlert(string msg)
        {
            var realm = AppDelegate.GetRealm();
            realm.Write(() => realm.RemoveAll());
            var okAlertController = UIAlertController.Create("OK", msg, UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default,
                obj => PerformSegue("UnwindSegue", this)));

            // Present Alert
            PresentViewController(okAlertController, true, null);
        }

        public override void ViewDidLoad()
        {
            ActivateKeyboardDetection(TopConstraint);
            base.ViewDidLoad();
        }

        partial void RegisterSubmit(NSObject sender)
        {
            var realm = AppDelegate.GetRealm();
            if (string.IsNullOrEmpty(RegistrationCodeField.Text))
                return;
            var customer = realm.All<CustomerModel>().FirstOrDefault();
            realm.Write(
                () => { customer.RegistrationCode = RegistrationCodeField.Text; }
            );
            var registerTask = customer.Register();
            registerTask.ContinueWith(arg => InvokeOnMainThread(() => PerformSegue("RegisterSegue", this)),
                TaskContinuationOptions.OnlyOnRanToCompletion);
            RefitErrorProcessing.Process(registerTask, this);
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            return true;
        }
    }
}
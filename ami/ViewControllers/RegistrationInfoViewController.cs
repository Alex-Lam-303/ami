using System;
using ami.Model;
using Foundation;
using Realms;
using UIKit;

namespace ami.ViewControllers
{
    public partial class RegistrationInfoViewController : UnhideTextFieldBaseViewController
    {
        public RegistrationInfoViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            ActivateKeyboardDetection(TopConstraint);
            base.ViewDidLoad();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var realm = AppDelegate.GetRealm();
            realm.Write(
                () => { realm.RemoveAll(); }
            );
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            var babyName = ChildNameField.Text;
            var email = EmailField.Text;
            var password = SettingsModel.GetStringSha256Hash(PasswordField.Text);
            if (string.IsNullOrEmpty(babyName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;
            var customer = new CustomerModel
            {
                Email = email,
                Password = password,
                BabyName = babyName
            };
            var setting = new SettingsModel
            {
                Customer = customer
            };
            var realm = AppDelegate.GetRealm();
            realm.Write(() => realm.Add(setting));
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }

        [Action("UnwindToRegistrationInfoViewController:")]
        public void UnwindToRegistrationInfoViewController(UIStoryboardSegue segue)
        {
            Console.WriteLine("We've unwinded to RegistrationInfo!");
        }
    }
}
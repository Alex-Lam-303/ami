using System;
using System.Linq;
using ami.Model;
using Foundation;
using Realms;

namespace ami.ViewControllers
{
    public partial class SetupNameViewController : UnhideTextFieldBaseViewController
    {
        public SetupNameViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ActivateKeyboardDetection(TopConstraint);
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier != "submitSegue") return base.ShouldPerformSegue(segueIdentifier, sender);
            var realm = AppDelegate.GetRealm();
            var settingsQuery = realm.All<SettingsModel>();
            var inputName = ChildNameField.Text;
            if (settingsQuery.Any())
            { 
                realm.Write(() => { settingsQuery.FirstOrDefault().ChildName = inputName; }); 
            }
            else
            {
                SettingsModel.CreateSettingInRealm();
                var setting = realm.All<SettingsModel>().FirstOrDefault();
                realm.Write(() => { setting.ChildName = inputName; });
            }
            //check if more than one
            return true;
        }
    }
}
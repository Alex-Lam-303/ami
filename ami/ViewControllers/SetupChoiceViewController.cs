using System;
using System.Linq;
using ami.Model;
using Realms;
using UIKit;
using Foundation;

namespace ami.ViewControllers
{
    public partial class SetupChoiceViewController : UIViewController
    {
        private VoiceCommandModel _commandFour;

        private VoiceCommandModel _commandOne;
        private VoiceCommandModel _commandThree;
        private VoiceCommandModel _commandTwo;
        private VoiceCommandPickerModel _pickerModel;


        public SetupChoiceViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _pickerModel = new VoiceCommandPickerModel();
            ChoicePicker.Model = _pickerModel;
            ChoiceOneButton.TouchUpInside += ChoiceOneButton_TouchUpInside;
            ChoiceTwoButton.TouchUpInside += ChoiceTwoButton_TouchUpInside;
            ChoiceThreeButton.TouchUpInside += ChoiceThreeButton_TouchUpInside;
            ChoiceFourButton.TouchUpInside += ChoiceFourButton_TouchUpInside;
            FinishButton.TouchUpInside += FinishButton_TouchUpInside;
        }

        private void ChoiceOneButton_TouchUpInside(object sender, EventArgs e)
        {
            _commandOne = _pickerModel.SelectedItem;
            ((UIButton) sender).SetTitle(_pickerModel.SelectedItem.Name, UIControlState.Normal);
        }

        private void ChoiceTwoButton_TouchUpInside(object sender, EventArgs e)
        {
            _commandTwo = _pickerModel.SelectedItem;
            ((UIButton) sender).SetTitle(_pickerModel.SelectedItem.Name, UIControlState.Normal);
        }

        private void ChoiceThreeButton_TouchUpInside(object sender, EventArgs e)
        {
            _commandThree = _pickerModel.SelectedItem;
            ((UIButton) sender).SetTitle(_pickerModel.SelectedItem.Name, UIControlState.Normal);
        }

        private void ChoiceFourButton_TouchUpInside(object sender, EventArgs e)
        {
            _commandFour = _pickerModel.SelectedItem;
            ((UIButton) sender).SetTitle(_pickerModel.SelectedItem.Name, UIControlState.Normal);
        }


        private void FinishButton_TouchUpInside(object sender, EventArgs e)
        {
            if (_commandOne != null && _commandTwo != null && _commandThree != null && _commandFour != null)
            {
                var realm = AppDelegate.GetRealm();
                var setting = realm.All<SettingsModel>().FirstOrDefault();
                realm.Write(() =>
                {
                    setting.CommandOne = _commandOne;
                    setting.CommandTwo = _commandTwo;
                    setting.CommandThree = _commandThree;
                    setting.CommandFour = _commandFour;
                });
                PresentViewController(AppDelegate.Storyboard.InstantiateViewController("MainTabController"), true,
                    null);
            }
            else
            {
                var alert = UIAlertController.Create("Commands", NSBundle.MainBundle.GetLocalizedString("Please Add All Four Commands Please"),
                    UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
                PresentViewController(alert, true, null);
            }
        }
    }
}
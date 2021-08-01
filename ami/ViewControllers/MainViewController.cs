using System;
using System.Threading.Tasks;
using System.Linq;
using ami.Helper;
using ami.Model;
using AVFoundation;
using Foundation;
using UIKit;
using AudioToolbox;

namespace ami.ViewControllers
{
    public partial class MainViewController : UnhideTextFieldBaseViewController, IErrorHandleViewController
    {
        AVAudioPlayer _player;
        SettingsModel _setting;

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public void PresentProblemAlert(string msg)
        {
            var okAlertController = UIAlertController.Create("Error", msg, UIAlertControllerStyle.Alert);
            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            // Present Alert
            PresentViewController(okAlertController, true, null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var setting = AppDelegate.GetRealm().All<SettingsModel>().FirstOrDefault();
            setting.ReSelectHost();
            ActivateKeyboardDetection(TopConstraint);
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.Ambient);
            session.SetActive(true);
            var realm = AppDelegate.GetRealm();
            _setting = realm.All<SettingsModel>().FirstOrDefault();
            // ReSharper disable once PossibleNullReferenceException
            if (_setting.CommandOne == null || _setting.CommandTwo == null || _setting.CommandThree == null ||
                _setting.CommandFour == null)
            {
                PresentViewController(AppDelegate.Storyboard.InstantiateViewController("SetupViewController"), true,
                    null);
                return;
            }
            ChoiceOneButton.SetTitle(_setting.CommandOne.Name, UIControlState.Normal);
            ChoiceTwoButton.SetTitle(_setting.CommandTwo.Name, UIControlState.Normal);
            ChoiceThreeButton.SetTitle(_setting.CommandThree.Name, UIControlState.Normal);
            ChoiceFourButton.SetTitle(_setting.CommandFour.Name, UIControlState.Normal);
            ChoiceOneButton.TouchUpInside += ChoiceOneButton_TouchUpInside;
            ChoiceTwoButton.TouchUpInside += ChoiceTwoButton_TouchUpInside;
            ChoiceThreeButton.TouchUpInside += ChoiceThreeButton_TouchUpInside;
            ChoiceFourButton.TouchUpInside += ChoiceFourButton_TouchUpInside;
            EditButton.TouchUpInside += EditButton_TouchUpInside;
            SuggestCommandButton.TouchUpInside += AddCommandSuggestionButton_TouchUpInside;
        }

        private void ChoiceOneButton_TouchUpInside(object sender, EventArgs e)
        {
            var url = NSUrl.FromString(_setting.CommandOne.Url);
            Console.WriteLine(url);
            PlayAudioFile(url);
        }

        private void ChoiceTwoButton_TouchUpInside(object sender, EventArgs e)
        {
            var url = NSUrl.FromString(_setting.CommandTwo.Url);
            PlayAudioFile(url);
        }

        private void ChoiceThreeButton_TouchUpInside(object sender, EventArgs e)
        {
            var url = NSUrl.FromString(_setting.CommandThree.Url);
            PlayAudioFile(url);
        }

        private void ChoiceFourButton_TouchUpInside(object sender, EventArgs e)
        {
            var url = NSUrl.FromString(_setting.CommandFour.Url);
            PlayAudioFile(url);
        }

        void PlayAudioFile(NSUrl url)
        {
            _player?.Stop();
            var caf = AudioFile.Open(url, AudioFilePermission.Read, AudioFileType.CAF);
            if (caf != null)
            {
                _player = AVAudioPlayer.FromUrl(url);
                _player.PrepareToPlay();
                _player.Play();
            }
            else
            {
                SettingsModel.UpdateAudiosInSetting();
            }
        }

        private void EditButton_TouchUpInside(object sender, EventArgs e)
        {
            PresentViewController(AppDelegate.Storyboard.InstantiateViewController("SetupViewController"), true, null);
        }

        private void AddCommandSuggestionButton_TouchUpInside(object sender, EventArgs e)
        {
            SuggestionField.ResignFirstResponder();
            //var speechSynthesizer = new AVSpeechSynthesizer ();
            //         var speechUtterance = new AVSpeechUtterance (SuggestionField.Text );
            //speechSynthesizer.SpeakUtterance (speechUtterance);
            var suggestTask = VoiceCommandModel.SuggestNewCommand(SuggestionField.Text);
            suggestTask.ContinueWith((arg) =>
            {
                InvokeOnMainThread(() =>
                {
                    SuggestionField.Text = "";
                    var okAlertController = UIAlertController.Create("Success",
                        "Suggestion Added! Our team will review and make changes.", UIAlertControllerStyle.Alert);
                    //Add Action
                    okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            ;
            RefitErrorProcessing.Process(suggestTask, this);
        }

        [Action("UnwindToMainViewController:")]
        public void UnwindToMainViewController(UIStoryboardSegue segue)
        {
            Console.WriteLine("We've unwinded to MainViewController!");
        }

        public override void ViewWillDisappear(bool animated)
        {
            _player?.Stop();
            base.ViewWillDisappear(animated);
        }
    }
}
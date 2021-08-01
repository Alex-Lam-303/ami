using System;
using Foundation;
using UIKit;

namespace ami.ViewControllers
{
    public class UnhideTextFieldBaseViewController : UIViewController
    {
        private nfloat _originalValue;
        private NSLayoutConstraint _topConstraint;

        public UnhideTextFieldBaseViewController()
        {
        }

        public UnhideTextFieldBaseViewController(IntPtr handle) : base(handle)
        {
        }

        protected void ActivateKeyboardDetection(NSLayoutConstraint top)
        {
            _topConstraint = top;
            _originalValue = _topConstraint.Constant;
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillChangeFrameNotification,
                OnKeyboardFrameChanged);
        }

        private void OnKeyboardFrameChanged(NSNotification notification)
        {
            if (!IsViewLoaded) return;
            //Start an animation, using values from the keyboard
            UIView.BeginAnimations("AnimateForKeyboard");
            UIView.SetAnimationBeginsFromCurrentState(true);
            UIView.SetAnimationDuration(UIKeyboard.AnimationDurationFromNotification(notification));
            UIView.SetAnimationCurve((UIViewAnimationCurve) UIKeyboard.AnimationCurveFromNotification(notification));
            var keyboardFrame = UIKeyboard.FrameEndFromNotification(notification);
            nfloat change = keyboardFrame.Height;
            if (UIScreen.MainScreen.NativeBounds.Height == 2436)
                change -= 100;
            if (keyboardFrame.Y >= View.Frame.Height)
                _topConstraint.Constant = _originalValue;
            else
                _topConstraint.Constant = -change;
            //Commit the animation
            UIView.CommitAnimations();
        }
    }
}
// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ami
{
    [Register ("AddCustomCommandViewController")]
    partial class AddCustomCommandViewController
    {
        [Outlet]
        UIKit.UIButton FinishButton { get; set; }


        [Outlet]
        UIKit.UIButton HoldToTalkButton { get; set; }


        [Outlet]
        UIKit.UITextField MessageNameField { get; set; }


        [Outlet]
        UIKit.UIButton PlayButton { get; set; }


        [Outlet]
        UIKit.UIButton RetryButton { get; set; }


        [Outlet]
        UIKit.UILabel StatusIndicationLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FinishButton != null) {
                FinishButton.Dispose ();
                FinishButton = null;
            }

            if (HoldToTalkButton != null) {
                HoldToTalkButton.Dispose ();
                HoldToTalkButton = null;
            }

            if (MessageNameField != null) {
                MessageNameField.Dispose ();
                MessageNameField = null;
            }

            if (PlayButton != null) {
                PlayButton.Dispose ();
                PlayButton = null;
            }

            if (RetryButton != null) {
                RetryButton.Dispose ();
                RetryButton = null;
            }

            if (StatusIndicationLabel != null) {
                StatusIndicationLabel.Dispose ();
                StatusIndicationLabel = null;
            }
        }
    }
}
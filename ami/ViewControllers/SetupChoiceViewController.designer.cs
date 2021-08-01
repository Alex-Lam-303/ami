// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ami.ViewControllers
{
    [Register ("SetupChoiceViewController")]
    partial class SetupChoiceViewController
    {
        [Outlet]
        UIKit.UIButton ChoiceFourButton { get; set; }


        [Outlet]
        UIKit.UIButton ChoiceOneButton { get; set; }


        [Outlet]
        UIKit.UIPickerView ChoicePicker { get; set; }


        [Outlet]
        UIKit.UIButton ChoiceThreeButton { get; set; }


        [Outlet]
        UIKit.UIButton ChoiceTwoButton { get; set; }



        [Outlet]
        UIKit.UIButton FinishButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ChoiceFourButton != null) {
                ChoiceFourButton.Dispose ();
                ChoiceFourButton = null;
            }

            if (ChoiceOneButton != null) {
                ChoiceOneButton.Dispose ();
                ChoiceOneButton = null;
            }

            if (ChoicePicker != null) {
                ChoicePicker.Dispose ();
                ChoicePicker = null;
            }

            if (ChoiceThreeButton != null) {
                ChoiceThreeButton.Dispose ();
                ChoiceThreeButton = null;
            }

            if (ChoiceTwoButton != null) {
                ChoiceTwoButton.Dispose ();
                ChoiceTwoButton = null;
            }

            if (FinishButton != null) {
                FinishButton.Dispose ();
                FinishButton = null;
            }
        }
    }
}
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
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        UIKit.UIButton ChoiceFourButton { get; set; }


        [Outlet]
        UIKit.UIButton ChoiceOneButton { get; set; }


        [Outlet]
        UIKit.UIButton ChoiceThreeButton { get; set; }


        [Outlet]
        UIKit.UIButton ChoiceTwoButton { get; set; }


        [Outlet]
        UIKit.UIButton EditButton { get; set; }


        [Outlet]
        UIKit.UIButton SuggestCommandButton { get; set; }


        [Outlet]
        UIKit.UITextField SuggestionField { get; set; }


        [Outlet]
        UIKit.NSLayoutConstraint TopConstraint { get; set; }

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

            if (ChoiceThreeButton != null) {
                ChoiceThreeButton.Dispose ();
                ChoiceThreeButton = null;
            }

            if (ChoiceTwoButton != null) {
                ChoiceTwoButton.Dispose ();
                ChoiceTwoButton = null;
            }

            if (EditButton != null) {
                EditButton.Dispose ();
                EditButton = null;
            }

            if (SuggestCommandButton != null) {
                SuggestCommandButton.Dispose ();
                SuggestCommandButton = null;
            }

            if (SuggestionField != null) {
                SuggestionField.Dispose ();
                SuggestionField = null;
            }

            if (TopConstraint != null) {
                TopConstraint.Dispose ();
                TopConstraint = null;
            }
        }
    }
}
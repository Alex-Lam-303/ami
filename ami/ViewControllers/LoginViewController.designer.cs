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
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        UIKit.UIButton ContinueButton { get; set; }


        [Outlet]
        UIKit.UITextField EmailField { get; set; }


        [Outlet]
        UIKit.UITextField PasswordField { get; set; }


        [Outlet]
        UIKit.NSLayoutConstraint TopConstraint { get; set; }


        [Action ("LoginSubmit:")]
        partial void LoginSubmit (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (ContinueButton != null) {
                ContinueButton.Dispose ();
                ContinueButton = null;
            }

            if (EmailField != null) {
                EmailField.Dispose ();
                EmailField = null;
            }

            if (PasswordField != null) {
                PasswordField.Dispose ();
                PasswordField = null;
            }

            if (TopConstraint != null) {
                TopConstraint.Dispose ();
                TopConstraint = null;
            }
        }
    }
}
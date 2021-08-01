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
    [Register ("RegistrationCodeViewController")]
    partial class RegistrationCodeViewController
    {
        [Outlet]
        UIKit.UITextField RegistrationCodeField { get; set; }


        [Outlet]
        UIKit.NSLayoutConstraint TopConstraint { get; set; }


        [Action ("RegisterSubmit:")]
        partial void RegisterSubmit (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (RegistrationCodeField != null) {
                RegistrationCodeField.Dispose ();
                RegistrationCodeField = null;
            }

            if (TopConstraint != null) {
                TopConstraint.Dispose ();
                TopConstraint = null;
            }
        }
    }
}
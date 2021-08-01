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
    [Register ("NewReminderChildViewController")]
    partial class NewReminderChildViewController
    {
        [Outlet]
        UIKit.UIPickerView ChoicePicker { get; set; }


        [Outlet]
        UIKit.UITableViewCell CommandCell { get; set; }


        [Outlet]
        UIKit.UITableViewCell TimeCell { get; set; }


        [Outlet]
        UIKit.UIDatePicker TimePicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ChoicePicker != null) {
                ChoicePicker.Dispose ();
                ChoicePicker = null;
            }

            if (CommandCell != null) {
                CommandCell.Dispose ();
                CommandCell = null;
            }

            if (TimeCell != null) {
                TimeCell.Dispose ();
                TimeCell = null;
            }

            if (TimePicker != null) {
                TimePicker.Dispose ();
                TimePicker = null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using ami.Model;
using Foundation;
using Realms;
using UIKit;

namespace ami.ViewControllers
{
    public partial class ReminderTableController : UITableViewController
    {
        private const string _cellId = "AlarmCell";
        private List<ReminderModel> _reminders = new List<ReminderModel>();

        public ReminderTableController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UpdateTable();
        }

        private void UpdateTable()
        {
            var realm = AppDelegate.GetRealm();
            var currentDate = DateTimeOffset.UtcNow;
            var expiredReminers = realm.All<ReminderModel>().Where(reminder => reminder.AlarmDate <= currentDate);

            if (expiredReminers.Any())
                realm.Write(
                    () =>
                    {
                        foreach (var expiredReminder in expiredReminers)
                            realm.Remove(expiredReminder);
                    }
                );
            _reminders = realm.All<ReminderModel>().ToList();
            TableView.ReloadData();
        }

        [Action("UnwindToReminderViewController:")]
        public void UnwindToReminderViewController(UIStoryboardSegue segue)
        {
            Console.WriteLine("Unwinded to reminder");
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            UpdateTable();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _reminders.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(_cellId);
            var reminder = _reminders[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, _cellId);
            cell.TextLabel.Text = reminder.AlarmDate.ToLocalTime().ToString("g");
            cell.DetailTextLabel.Text = reminder.Name;
            return cell;
        }
    }
}
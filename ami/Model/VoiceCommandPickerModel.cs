using System;
using System.Linq;
using Realms;
using UIKit;

namespace ami.Model
{
    public class VoiceCommandPickerModel : UIPickerViewModel
    {
        private readonly SettingsModel _setting;
        private int _selectedIndex;

        public VoiceCommandPickerModel()
        {
            var realm = AppDelegate.GetRealm();
            _setting = realm.All<SettingsModel>().FirstOrDefault();
        }

        public VoiceCommandModel SelectedItem => _setting.VoiceCommands[_selectedIndex];
        public event EventHandler<EventArgs> ValueChanged;

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return _setting.VoiceCommands.Count();
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return _setting.VoiceCommands[Convert.ToInt32(row)].Name;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            _selectedIndex = Convert.ToInt32(row);
            ValueChanged?.Invoke(this, new EventArgs());
        }

        public void AddCustomCommand(VoiceCommandModel model)
        {
            var realm = AppDelegate.GetRealm();
            realm.Write(() => { _setting.VoiceCommands.Add(model); });
        }
    }
}
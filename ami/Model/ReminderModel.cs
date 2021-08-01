using System;
using Realms;

namespace ami.Model
{
    public class ReminderModel : RealmObject
    {
        public DateTimeOffset AlarmDate { get; set; }
        public string Name { get; set;}

        [Ignored]
        public VoiceCommandModel Command { get; set; }

        [PrimaryKey]
        public string RequestId { get; set; }
    }
}
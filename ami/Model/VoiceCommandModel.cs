using System.Threading.Tasks;
using ami.RefitInterfaces;
using Realms;
using Foundation;

namespace ami.Model
{
    public class VoiceCommandModel : RealmObject
    {
        
        public string FileName { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public static VoiceCommandModel FromFile(string name)
        {
            return new VoiceCommandModel
            {
                FileName = "Audios/" + name + ".caf",
                Name = name,
                Url = NSUrl.FromFilename("Audios/" + name + ".caf").ToString()
            };
        }

        public static Task SuggestNewCommand(string command)
        {
            var contentAPI = SettingsModel.GetRestInterface<IContentApi>("Content");
            return contentAPI.SuggestNewCommands(command);
        }
    }
}
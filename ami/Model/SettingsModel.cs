using System;using System.Collections.Generic;using System.Net.Http;using System.Security.Cryptography;using System.Text;using Realms;using Refit;using Plugin.Connectivity;using System.IO;using System.Threading.Tasks;
using System.Linq;using Foundation;

namespace ami.Model{    public class SettingsModel : RealmObject    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public IList<VoiceCommandModel> VoiceCommands { get; }        public string LanguageCode { get; set; }        public string ChildName { get; set; }        public CustomerModel Customer { get; set; }        public VoiceCommandModel CommandOne { get; set; }        public VoiceCommandModel CommandTwo { get; set; }        public VoiceCommandModel CommandThree { get; set; }        public VoiceCommandModel CommandFour { get; set; }        public static string Host { get; set; } = "https://ami-kidz.oss-cn-beijing.aliyuncs.com";        public bool DetectCommandSelection()        {            return CommandOne != null && CommandTwo != null && CommandThree != null && CommandFour != null;        }        public void ReSelectHost()        {            var connectivity = CrossConnectivity.Current;            connectivity.IsRemoteReachable("facebook.com", msTimeout: 2000).ContinueWith((arg) =>            {                var reachability = arg.Result;                if (reachability)                {                    SettingsModel.Host = "https://s3.us-east-2.amazonaws.com/amimultimedia";                }            }, TaskContinuationOptions.OnlyOnRanToCompletion);        }        public static IEnumerable<VoiceCommandModel> getAllFromCurrentDirectory(string languageCode)        {            return Directory.EnumerateFiles(NSBundle.MainBundle.BundlePath + "/Audios_" + languageCode)                                            .Select(Path.GetFileName)                                            .Select((arg) => new VoiceCommandModel()                                            {
                                                Url = NSUrl.FromFilename("Audios_" + languageCode + "/" + arg).ToString(),                                                Name = DecodeBase64(arg.Remove(arg.Length - 4)),                                                FileName = arg                                            });        }        public static void CreateSettingInRealm()        {            var setting = new SettingsModel();            var realm = AppDelegate.GetRealm();            setting.LanguageCode = NSBundle.MainBundle.PreferredLocalizations[0];            var voiceCommandList = getAllFromCurrentDirectory(setting.LanguageCode);
            //voiceCommandList = new List<VoiceCommandModel>
            //{
            //    VoiceCommandModel.FromFile("Brush your teeth"),
            //    VoiceCommandModel.FromFile("Eat vegetables"),
            //    VoiceCommandModel.FromFile("Hi, I'm Penny"),
            //    VoiceCommandModel.FromFile("How was your day"),
            //    VoiceCommandModel.FromFile("Take a shower"),
            //    VoiceCommandModel.FromFile("Take medicine"),
            //    VoiceCommandModel.FromFile("Time For Bed"),
            //    VoiceCommandModel.FromFile("Wake up"),
            //    VoiceCommandModel.FromFile("Wash hands for dinner"),
            //    VoiceCommandModel.FromFile("Let's go read a story together"),
            //    VoiceCommandModel.FromFile("Brush your hair"),
            //    VoiceCommandModel.FromFile("Clean up your mess"),
            //    VoiceCommandModel.FromFile("Get ready for daycare"),
            //    VoiceCommandModel.FromFile("Let mummy trim your toenail"),
            //    VoiceCommandModel.FromFile("Be ready for your playdate"),
            //    VoiceCommandModel.FromFile("Use inside Voice"),
            //    VoiceCommandModel.FromFile("Go downstairs for daddy"),
            //    VoiceCommandModel.FromFile("Trim your fingernails"),
            //    VoiceCommandModel.FromFile("Please say thank you"),
            //    VoiceCommandModel.FromFile("Wash Your Face"),
            //    VoiceCommandModel.FromFile("Go downstairs for mummy"),
            //};
            realm.Write(() =>
            {
                realm.Add(setting);
                foreach (var command in voiceCommandList)
                {
                    setting.VoiceCommands.Add(command);
                }
            });        }        public static void UpdateAudiosInSetting()        {            var realm = AppDelegate.GetRealm();            var setting = realm.All<SettingsModel>().FirstOrDefault();            Console.WriteLine("Updating  Settings");            realm.Write(() =>
            {
                var userAdded = setting.VoiceCommands.Where((arg) => DecodeBase64(arg.FileName.Remove(arg.FileName.Length - 4)) != arg.Name).ToList();                var voiceCommandsFromFile = getAllFromCurrentDirectory(setting.LanguageCode);                var combinedList = userAdded.Concat(voiceCommandsFromFile);                setting.CommandOne = UpdateSelectedModel(setting.CommandOne, combinedList);                setting.CommandTwo = UpdateSelectedModel(setting.CommandTwo, combinedList);                setting.CommandThree = UpdateSelectedModel(setting.CommandThree, combinedList);                setting.CommandFour = UpdateSelectedModel(setting.CommandFour, combinedList);                foreach (var element in setting.VoiceCommands)                {                    setting.VoiceCommands.Remove(element);                    realm.Remove(element);                }                foreach (var element in combinedList)                {                    setting.VoiceCommands.Add(element);                }

            });        }        public static VoiceCommandModel UpdateSelectedModel(VoiceCommandModel previous, IEnumerable<VoiceCommandModel> newModels)        {            return newModels.FirstOrDefault((arg) => arg.Name == previous.Name);        }        public static T GetRestInterface<T>(string subgroup)        {            var configuredHttpClient = new HttpClient();            configuredHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");            configuredHttpClient.BaseAddress = new Uri(Host + "/" + subgroup);            return RestService.For<T>(configuredHttpClient);        }        internal static string GetStringSha256Hash(string text)        {            if (string.IsNullOrEmpty(text))                return string.Empty;            using (var sha = new SHA256Managed())            {                var textData = Encoding.UTF8.GetBytes(text);                var hash = sha.ComputeHash(textData);                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();            }        }        internal static string DecodeBase64(string text)        {            return Encoding.UTF8.GetString(Convert.FromBase64String(text));        }    }}
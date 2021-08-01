﻿using System;
using System.Linq;

namespace ami.Model
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public IList<VoiceCommandModel> VoiceCommands { get; }
                                                Url = NSUrl.FromFilename("Audios_" + languageCode + "/" + arg).ToString(),
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
            });
            {
                var userAdded = setting.VoiceCommands.Where((arg) => DecodeBase64(arg.FileName.Remove(arg.FileName.Length - 4)) != arg.Name).ToList();

            });
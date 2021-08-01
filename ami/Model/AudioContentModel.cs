using System;

namespace ami.Model
{
    public class AudioContentModel
    {
        public string ContentName { get; set; }

        public Uri FileName { get; set; }

        public bool Relative { get; set; }
    }
}
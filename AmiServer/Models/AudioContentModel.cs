using System;
using System.Diagnostics.CodeAnalysis;

namespace AmiServer.Models
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public class AudioContentModel
    {
        public string ContentName { get; set; }

        public Uri Path { get; set; }
        //public Uri IconPath { get; set; }
    }
}